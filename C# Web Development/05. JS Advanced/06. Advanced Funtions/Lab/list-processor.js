function solve(input) {
    let result = [];

    let commands = {
        add(element) {
            result.push(element);
        },
        remove(element) {
            result = result.filter(x => x !== element);
        },
        print() {
            console.log(result);
        }
    };

    for (const currCommand of input) {
        let currCommandSplit = currCommand.split(' ');

        switch (currCommandSplit[0]) {
            case 'add':
                commands.add(currCommandSplit[1]);
                break;

            case 'remove':
                commands.remove(currCommandSplit[1]);
                break;

            case 'print':
                commands.print();
                break;
        }
    }
}

function solve(input) {
    let result = [];

    for (const currCommand of input) {
        let currCommandSplit = currCommand.split(' ');

        switch (currCommandSplit[0]) {
            case 'add':
                result.push(currCommandSplit[1]);
                break;

            case 'remove':
                result = result.filter(x => x !== currCommandSplit[1]);
                break;

            case 'print':
                console.log(result.join(','));
                break;
        }
    }
}

solve(['add hello', 'add again', 'remove hello', 'add again', 'print']);
solve(['add pesho', 'add george', 'add peter', 'remove peter', 'print']);