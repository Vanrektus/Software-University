class Stringer {
    constructor(inputString, length) {
        this.innerString = inputString;
        this.innerLength = length;
    }

    increase(length) {
        this.innerLength += length;
    }

    decrease(length) {
        this.innerLength -= length;

        if (this.innerLength < 0) {
            this.innerLength = 0;
        }
    }

    toString() {
        let result = '';

        if (this.innerString.length > this.innerLength) {
            for (let i = 0; i < this.innerLength; i++) {
                result += this.innerString[i];
            }

            result += '...';
        } else if (this.innerLength >= this.innerString.length) {
            for (let i = 0; i < this.innerString.length; i++) {
                result += this.innerString[i];
            }
        } else if (this.innerString.length == 0) {
            result = '...';
        }

        return result;
    }
}

let test = new Stringer("Test", 5);
console.log(test.toString()); // Test

test.decrease(3);
console.log(test.toString()); // Te...

test.decrease(5);
console.log(test.toString()); // ...

test.increase(4);
console.log(test.toString()); // Test