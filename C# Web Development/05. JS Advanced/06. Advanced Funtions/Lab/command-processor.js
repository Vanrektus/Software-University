function solution() {
    let result = '';

    return {
        append(text) {
            result += text;
        },
        removeStart(index) {
            result = result.substring(index);
        },
        removeEnd(index) {
            result = result.substring(0, result.length - index);
        },
        print() {
            console.log(result);
        }
    }
}

let firstZeroTest = solution();
firstZeroTest.append('hello');
firstZeroTest.append('again');
firstZeroTest.removeStart(3);
firstZeroTest.removeEnd(4);
firstZeroTest.print();

let secondZeroTest = solution();
secondZeroTest.append('123');
secondZeroTest.append('45');
secondZeroTest.removeStart(2);
secondZeroTest.removeEnd(1);
secondZeroTest.print();