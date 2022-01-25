function solve(inputCommands) {
    let result = {};

    let commands = {
        create(name) {
            result[name] = {};
        },
        createInherit(name, parentName) {
            this.create(name);

            let currCar = result[name];
            currCar = Object.setPrototypeOf(currCar, result[parentName]);
        },
        set(name, key, value) {
            result[name][key] = value;
        },
        print(name) {
            let print = '';
            const carToPrint = result[name];

            for (const currCar in carToPrint) {
                print += `${currCar}:${carToPrint[currCar]},`;
            }

            console.log(print.slice(0, -1));
        }
    };

    for (const currCommand of inputCommands) {
        let currCommandSplit = currCommand.split(' ');

        switch (currCommandSplit[0]) {
            case 'create':
                let car;

                if (currCommandSplit[2]) {
                    commands.createInherit(currCommandSplit[1], currCommandSplit[3]);
                } else {
                    commands.create(currCommandSplit[1]);
                }
                break;

            case 'set':
                commands.set(currCommandSplit[1], currCommandSplit[2], currCommandSplit[3]);
                break;

            case 'print':
                commands.print(currCommandSplit[1]);
                break;
        }
    }
}

solve(['create c1',
    'create c2 inherit c1',
    'set c1 color red',
    'set c2 model new',
    'print c1',
    'print c2'
]);