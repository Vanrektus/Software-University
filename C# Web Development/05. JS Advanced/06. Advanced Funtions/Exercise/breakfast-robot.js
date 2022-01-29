solve = (() => {
    const commands = {
        upvote: (post) => post.upvotes++,
        downvote: (post) => post.downvotes++,
        score: (post) => {
            let { upvotes, downvotes } = post;
            let total = upvotes + downvotes;

            let obfuscated = Math.ceil(0.25 * Math.max(upvotes, downvotes));
            let obfuscatedUpVotes = upvotes + obfuscated;
            let obfuscatedDownVotes = downvotes + obfuscated;
            let balance = obfuscatedUpVotes - obfuscatedDownVotes;

            let rating = '';

            if (total < 10) {
                rating = 'new';
            } else if (upvotes > total * 0.66) {
                rating = 'hot';
            } else if (balance >= 0 && (upvotes > 100 || downvotes > 100)) {
                rating = 'controversial';
            } else if (balance < 0) {
                rating = 'unpopular';
            } else {
                rating = 'new';
            }
            if (total > 50) {
                return [obfuscatedUpVotes, obfuscatedDownVotes, balance, rating];
            }
            return [upvotes, downvotes, balance, rating];
        }
    };

    return { call: (post, command) => commands[command](post) }
})();

let post = {
    id: '3',
    author: 'emil',
    content: 'wazaaaaa',
    upvotes: 100,
    downvotes: 100
};
solve.call(post, 'upvote');
solve.call(post, 'downvote');
let score = solve.call(post, 'score'); // [127, 127, 0, 'controversial']
solve.call(post, 'downvote');… // (executed 50 times)
score = solve.call(post, 'score'); // [139, 189, -50, 'unpopular']
function prepare(recipe, quantity) {
    const remainingStorage = {};

    for (const element in recipes[recipe]) {
        const remaining = storage[element] - recipes[recipe][element] * quantity;

        if (remaining < 0) {
            return `Error: not enough ${element} in stock`;
        } else {
            remainingStorage[element] = remaining;
        }
    }

    Object.assign(storage, remainingStorage);
    return 'Success';
}

function report() {
    return `protein=${storage.protein} carbohydrate=${storage.carbohydrate} fat=${storage.fat} flavour=${storage.flavour}`;
}

return function control(input) {
    let [command, argument, quantity] = input.split(' ');
    quantity = Number(quantity);

    switch (command) {
        case 'restock':
            return restock(argument, quantity);

        case 'prepare':
            return prepare(argument, quantity);

        case 'report':
            return report();
    }
}
}



function solution2() {
    const storage = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0,
    };

    const recipes = {
        'apple': (quantity) => {
            if (storage.carbohydrate - 1 * quantity < 0) return 'carbohydrate';
            if (storage.flavour - 2 * quantity < 0) return 'flavour';

            storage.carbohydrate -= 1 * quantity;
            storage.flavour -= 2 * quantity;
            return 'Success';
        },
        'lemonade': (quantity) => {
            if (storage.carbohydrate - 10 * quantity < 0) return 'carbohydrate';
            if (storage.flavour - 20 * quantity < 0) return 'flavour';

            storage.carbohydrate -= 10 * quantity;
            storage.flavour -= 20 * quantity;
            return 'Success';
        },
        'burger': (quantity) => {
            if (storage.carbohydrate - 5 * quantity < 0) return 'carbohydrate';
            if (storage.fat - 7 * quantity < 0) return 'fat';
            if (storage.flavour - 3 * quantity < 0) return 'flavour';

            storage.carbohydrate -= 5 * quantity;
            storage.fat -= 7 * quantity;
            storage.flavour -= 3 * quantity;
            return 'Success';
        },
        'eggs': (quantity) => {
            if (storage.protein - 5 * quantity < 0) return 'protein';
            if (storage.fat - 1 * quantity < 0) return 'fat';
            if (storage.flavour - 1 * quantity < 0) return 'flavour';

            storage.protein -= 5 * quantity;
            storage.fat -= 1 * quantity;
            storage.flavour -= 1 * quantity;
            return 'Success';
        },
        'turkey': (quantity) => {
            if (storage.protein - 10 * quantity < 0) return 'protein';
            if (storage.carbohydrate - 10 * quantity < 0) return 'carbohydrate';
            if (storage.fat - 10 * quantity < 0) return 'fat';
            if (storage.flavour - 10 * quantity < 0) return 'flavour';

            storage.protein -= 10 * quantity;
            storage.carbohydrate -= 10 * quantity
            storage.fat -= 10 * quantity;
            storage.flavour -= 10 * quantity;
            return 'Success';
        },
    }

    return function(input) {
        let [command, argument, quantity] = input.split(' ');
        quantity = Number(quantity);

        switch (command) {
            case 'restock':
                storage[argument] += quantity;
                return 'Success';

            case 'prepare':
                let message = recipes[argument](quantity);

                return (message === 'Success') ? 'Success' : `Error: not enough ${message} in stock`;

            case 'report':
                return `protein=${storage.protein} carbohydrate=${storage.carbohydrate} fat=${storage.fat} flavour=${storage.flavour}`;
        }
    }
}



let manager = solve();
console.log(manager("restock flavour 50")); // Success
console.log(manager("prepare lemonade 4")); // Error: not enough carbohydrate in stock

console.log('===========================');

let manager2 = solve();
console.log(manager2("restock carbohydrate 10")); // Success
console.log(manager2("restock flavour 10")); // Success
console.log(manager2("prepare apple 1")); // Success
console.log(manager2("restock fat 10")); // Success
console.log(manager2("prepare burger 1")); // Success
console.log(manager2("report")); // protein=0 carbohydrate=4 fat=3 flavour=5

console.log('===========================');

let manager3 = solve();
console.log(manager3("prepare turkey 1")); // Error: not enough protein in stock
console.log(manager3("restock protein 10")); // Success
console.log(manager3("prepare turkey 1")); // Error: not enough carbohydrate in stock
console.log(manager3("restock carbohydrate 10")); // Success
console.log(manager3("prepare turkey 1")); // Error: not enough fat in stock
console.log(manager3("restock fat 10")); // Success
console.log(manager3("prepare turkey 1")); // Error: not enough flavour in stock
console.log(manager3("restock flavour 10")); // Success
console.log(manager3("prepare turkey 1")); // Success
console.log(manager3("report")); // protein=0 carbohydrate=0 fat=0 flavour=0