function solve(input) {
    debugger;
    let biggestNumber = Number.MIN_SAFE_INTEGER;

    for (let row = 0; row < input.length; row++) {
        for (let col = 0; col < input[row].length; col++) {
            if (input[row][col] > biggestNumber) {
                biggestNumber = input[row][col];
            }
        }
    }

    console.log(biggestNumber);
}

solve([
    [20, 50, 10],
    [8, 33, 145],
]);
solve([
    [3, 5, 7, 12],
    [-1, 4, 33, 2],
    [8, 3, 0, 4],
]);
