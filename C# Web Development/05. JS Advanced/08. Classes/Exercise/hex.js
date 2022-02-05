class Hex {
    constructor(number) {
        this.value = number;
    }

    valueOf() {
        return this.value;
    }

    toString() {
        return `0x${this.value.toString(16).toUpperCase()}`;
    }

    plus(numberOrHexInput) {
        if (Number(numberOrHexInput)) {
            return new Hex(this.value + numberOrHexInput);
        }

        return new Hex(parseInt(numberOrHexInput.value, 16) + this.value);
    }

    minus(numberOrHexInput) {
        if (Number(numberOrHexInput)) {
            return new Hex(this.value - numberOrHexInput);
        }

        return new Hex(parseInt(numberOrHexInput.value, 16) - this.value);
    }

    parse(string) {
        return parseInt(string, 16)
    }
}

let FF = new Hex(255);
console.log(FF.toString());
FF.valueOf() + 1 == 256;
let a = new Hex(10);
let b = new Hex(5);
console.log(a.plus(b).toString());
console.log(a.plus(b).toString() === '0xF');
console.log(FF.parse('AAA'));