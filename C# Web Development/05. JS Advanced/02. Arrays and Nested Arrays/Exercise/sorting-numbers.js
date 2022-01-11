function solve(inputArray) {
    inputArray.sort((a, b) => a - b);
    let inputArrayOriginalLength = inputArray.length;
    let resultArray = [];

    for (let i = 0; i < inputArrayOriginalLength; i++) {
        if (i % 2 == 0) {
            resultArray.push(inputArray.shift());
        } else {
            resultArray.push(inputArray.pop());
        }
    }

    return resultArray;
}

console.log(solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));
