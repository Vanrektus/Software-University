function solve(input) {
    input.sort((a, b) => a - b);

    let middleOfArray = Math.floor(input.length / 2);

    return input.slice(middleOfArray);
}

console.log(solve([4, 7, 2, 5]));
console.log(solve([3, 19, 14, 7, 2, 19, 6]));