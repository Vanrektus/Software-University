function solve(inputArray) {
    let resultArray = [];
    let currentBiggestNumber = Number.MIN_SAFE_INTEGER;

    for (const currentElement of inputArray) {
        if (currentElement >= currentBiggestNumber) {
            currentBiggestNumber = currentElement;
            resultArray.push(currentElement);
        }
    }

    return resultArray;
}

console.log(solve([1, 3, 8, 4, 10, 12, 3, 2, 24]));
console.log(solve([1, 2, 3, 4]));
console.log(solve([20, 3, 2, 15, 6, 1]));
