function solve(input) {
    let totalEqualPairs = 0;
    debugger;
    for (let row = 0; row < input.length; row++) {
        for (let col = 0; col < input[row].length; col++) {
            if (row == input.length - 1) {
                if (input[row][col] === input[row][col + 1]) {
                    totalEqualPairs++;
                }
            } else {
                if (input[row][col] === input[row][col + 1]) {
                    totalEqualPairs++;
                }

                if (input[row][col] === input[row + 1][col]) {
                    totalEqualPairs++;
                }
            }
        }
    }

    return totalEqualPairs;
}

console.log(
    solve([
        ["2", "3", "4", "7", "0"],
        ["4", "0", "5", "3", "4"],
        ["2", "3", "5", "4", "2"],
        ["9", "8", "7", "5", "4"],
    ])
);
console.log(
    solve([
        ["test", "yes", "yo", "ho"],
        ["well", "done", "yo", "6"],
        ["not", "done", "yet", "5"],
    ])
);
console.log(
    solve([
        ["2", "2", "5", "7", "4"],
        ["4", "0", "5", "3", "4"],
        ["2", "5", "5", "4", "2"],
    ])
);
console.log(
    solve([
        ["2", "2", "5", "4", "4"],
        ["4", "0", "5", "3", "4"],
        ["2", "5", "5", "4", "2"],
    ])
);
console.log(
    solve([
        ["2", "2", "5", "4", "4"],
        ["4", "0", "5", "4", "4"],
        ["2", "5", "5", "4", "2"],
    ])
);
