function solve() {
    class Balloon {
        constructor(color, weight) {
            this.color = color;
            this.hasWeight = Number(weight);
        }
    }

    class PartyBalloon extends Balloon {
        constructor(color, weight, ribbonColor, ribbonLength) {
            super(color, weight);

            this.ribbonColor = ribbonColor;
            this.ribbonLength = ribbonLength;

            this._ribbon = {
                color: ribbonColor,
                length: ribbonLength,
            }
        }

        get ribbon() {
            return this._ribbon;
        }
    }

    class BirthdayBalloon extends PartyBalloon {
        constructor(color, weight, ribbonColor, ribbonLength, text) {
            super(color, weight, ribbonColor, ribbonLength);

            this._text = text;
        }

        get text() {
            return this._text;
        }
    }

    return {
        Balloon,
        PartyBalloon,
        BirthdayBalloon,
    };
}

let classes = solve();
let partyBalloon = new classes.PartyBalloon('red', 10, 'white', 5);
let birthdayBalloon = new classes.BirthdayBalloon('orange', 100, 'black', 15, 'Happy Birthday');

console.log(partyBalloon.ribbon);
console.log(birthdayBalloon.ribbon);
console.log(birthdayBalloon.text);