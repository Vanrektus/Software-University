class SummerCamp {
    constructor(organizer, location) {
        this.organizer = organizer;
        this.location = location;
        this.priceForTheCamp = { "child": 150, "student": 300, "collegian": 500 };
        this.listOfParticipants = [];
    }

    registerParticipant(name, condition, money) {
        if (condition !== "child" && condition !== "student" && condition !== "collegian") {
            throw new Error("Unsuccessful registration at the camp.");
        }

        if (this.listOfParticipants.some(x => x.name === name)) {
            return `The ${name} is already registered at the camp.`;
        }

        if (money < this.priceForTheCamp[condition]) {
            return `The money is not enough to pay the stay at the camp.`;
        }

        this.listOfParticipants.push({
            name,
            condition,
            power: 100,
            wins: 0
        });
        return `The ${name} was successfully registered.`
    }

    unregisterParticipant(name) {
        if (!this.listOfParticipants.some(x => x.name === name)) {
            throw new Error(`The ${name} is not registered in the camp.`);
        }

        this.listOfParticipants = this.listOfParticipants.filter(x => x.name !== name);

        return `The ${name} removed successfully.`;
    }

    timeToPlay(typeOfGame, participant1, participant2) {
        let playerOne = this.listOfParticipants.find(x => x.name === participant1);
        let playerTwo = this.listOfParticipants.find(x => x.name === participant2);

        switch (typeOfGame) {
            case 'Battleship':
                if (!playerOne) {
                    throw new Error('Invalid entered name/s.');
                }

                playerOne.power += 20;

                return `The ${playerOne.name} successfully completed the game ${typeOfGame}.`;

            case 'WaterBalloonFights':
                if (!playerOne || !playerTwo) {
                    throw new Error('Invalid entered name/s.');
                }

                if (playerOne.condition !== playerTwo.condition) {
                    throw new Error('Choose players with equal condition.');
                }

                if (playerOne.power === playerTwo.power) {
                    return `There is no winner.`;
                }

                if (playerOne.power > playerTwo.power) {
                    playerOne.wins++;

                    return `The ${playerOne.name} is winner in the game ${typeOfGame}.`
                } else {
                    playerTwo.wins++;

                    return `The ${playerTwo.name} is winner in the game ${typeOfGame}.`
                }
        }
    }

    toString() {
        let output = `${this.organizer} will take ${this.listOfParticipants.length} participants on camping to ${this.location}`;

        this.listOfParticipants.sort((a, b) => b.wins - a.wins).forEach(x => output += `\n${x.name} - ${x.condition} - ${x.power} - ${x.wins}`);

        return output;
    }
}

// Mine
// const summerCamp = new SummerCamp("Jane Austen", "Pancharevo Sofia 1137, Bulgaria");
// console.log(summerCamp.registerParticipant("Petar Petarson", "child", 300));
// console.log(summerCamp.registerParticipant("Sara Dickinson", "child", 200));
// console.log(summerCamp.timeToPlay("Battleship", "Sara Dickinson"));
// console.log(summerCamp.timeToPlay("WaterBalloonFights", "Petar Petarson", "Sara Dickinson"));
// console.log(summerCamp.toString());

// Mine 2
// console.log(summerCamp.registerParticipant("Ivan", "student", 700));
// console.log(summerCamp.registerParticipant("Gosho", "student", 700));
// console.log(summerCamp.registerParticipant("Tosho", "child", 700));
// console.log(summerCamp.timeToPlay("WaterBalloonFights", "Ivan", "Gosho"));
// console.log(summerCamp.timeToPlay("Battleship", "Ivan"));
// console.log(summerCamp.timeToPlay("WaterBalloonFights", "Ivan", "Gosho"));
// console.log(summerCamp.toString());

// 1
// const summerCamp = new SummerCamp("Jane Austen", "Pancharevo Sofia 1137, Bulgaria");
// console.log(summerCamp.registerParticipant("Petar Petarson", "student", 200));
// console.log(summerCamp.registerParticipant("Petar Petarson", "student", 300));
// console.log(summerCamp.registerParticipant("Petar Petarson", "student", 300));
// console.log(summerCamp.registerParticipant("Leila Wolfe", "childd", 200));

// The money is not enough to pay the stay at the camp.
// The Petar Petarson was successfully registered.
// The Petar Petarson is already registered at the camp.
// Uncaught Error: Unsuccessful registration at the camp.

// 2
// const summerCamp = new SummerCamp("Jane Austen", "Pancharevo Sofia 1137, Bulgaria");
// console.log(summerCamp.registerParticipant("Petar Petarson", "student", 300));
// console.log(summerCamp.unregisterParticipant("Petar"));
// console.log(summerCamp.unregisterParticipant("Petar Petarson"));

// The Petar Petarson was successfully registered.
// Uncaught Error: The Petar is not registered in the camp.
// The Petar Petarson removed successfully.

// 3
// const summerCamp = new SummerCamp("Jane Austen", "Pancharevo Sofia 1137, Bulgaria");
// console.log(summerCamp.registerParticipant("Petar Petarson", "student", 300));
// console.log(summerCamp.timeToPlay("Battleship", "Petar Petarson"));
// console.log(summerCamp.registerParticipant("Sara Dickinson", "child", 200));
// console.log(summerCamp.timeToPlay("WaterBalloonFights", "Petar Petarson", "Sara Dickinson"));
// console.log(summerCamp.registerParticipant("Dimitur Kostov", "student", 300));
// console.log(summerCamp.timeToPlay("WaterBalloonFights", "Petar Petarson", "Dimitur Kostov"));

// The Petar Petarson was successfully registered.
// The Petar Petarson successfully completed the game Battleship.
// The Sara Dickinson was successfully registered.
// Uncaught Error: Choose players with equal condition.
// The Dimitur Kostov was successfully registered.
// The Petar Petarson is winner in the game WaterBalloonFights.

// 4
// const summerCamp = new SummerCamp("Jane Austen", "Pancharevo Sofia 1137, Bulgaria");
// console.log(summerCamp.registerParticipant("Petar Petarson", "student", 300));
// console.log(summerCamp.timeToPlay("Battleship", "Petar Petarson"));
// console.log(summerCamp.registerParticipant("Sara Dickinson", "child", 200));
// console.log(summerCamp.timeToPlay("WaterBalloonFights", "Petar Petarson", "Sara Dickinson"));
// console.log(summerCamp.registerParticipant("Dimitur Kostov", "student", 300));
// console.log(summerCamp.timeToPlay("WaterBalloonFights", "Petar Petarson", "Dimitur Kostov"));

// console.log(summerCamp.toString());

// The Petar Petarson was successfully registered.
// The Petar Petarson successfully completed the game Battleship.
// The Sara Dickinson was successfully registered.
// Uncaught Error: Choose players with equal condition.
// The Dimitur Kostov was successfully registered.
// The Petar Petarson is winner in the game WaterBalloonFights.
// Jane Austen will take 3 participants on camping to Pancharevo Sofia 1137, Bulgaria
// Petar Petarson - student - 120 - 1
// Sara Dickinson - child - 100 - 0
// Dimitur Kostov - student - 100 - 0