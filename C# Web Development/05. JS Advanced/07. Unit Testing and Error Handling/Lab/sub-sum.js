function solve(numArr, startIndex, endIndex) {
    if (!Array.isArray(numArr)) {
        return NaN;
    }

    if (startIndex < 0) {
        startIndex = 0;
    }

    if (endIndex > numArr.lenght - 1) {
        endIndex = numArr.lenght - 1;
    }

    return numArr.slice(startIndex, endIndex + 1).map(Number).reduce((a, x) => a + x, 0);
}

console.log(solve([10, 20, 30, 40, 50, 60], 3, 300));
console.log(solve([1.1, 2.2, 3.3, 4.4, 5.5], -3, 1));
console.log(solve([10, 'twenty', 30, 40], 0, 2));
console.log(solve([], 1, 2));
console.log(solve('text', 0, 2));