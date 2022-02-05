function solve(inputArr) {
    let juices = new Map();
    let madeJuices = new Map();

    for (const currJuice of inputArr) {
        let [flavor, quantity] = currJuice.split(' => ');

        if (!juices.has(flavor)) {
            juices.set(flavor, 0);
        }

        juices.set(flavor, juices.get(flavor) + Number(quantity));

        while (juices.get(flavor) >= 1000) {
            juices.set(flavor, juices.get(flavor) - 1000);
            madeJuices.set(flavor, (madeJuices.get(flavor) || 0) + 1);
        }
    }

    for (const [flavor, quantity] of madeJuices) {
        console.log(`${flavor} => ${quantity}`);
    }
}

solve(['Orange => 2000',
    'Peach => 1432',
    'Peach => 600',
    'Strawberry => 549'
]);
solve(['Kiwi => 234',
    'Banana => 2345',
    'Watermelon => 3456',
    'Kiwi => 4567',
    'Banana => 5678',
    'Watermelon => 6789'
]);