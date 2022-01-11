function solve(inputMatrix) {
    let magicSum = inputMatrix[0].reduce((acc, curr) => acc + curr);
    let isMagicMatrix = true;
    debugger;

    for (let row = 0; row < inputMatrix.length; row++) {
        let currentRowSum = inputMatrix[row].reduce((acc, curr) => acc + curr);
        let currentColSum = 0;

        if (currentRowSum != magicSum) {
            isMagicMatrix = false;
            return false;
        }

        for (let col = 0; col < inputMatrix.length; col++) {
            currentColSum += inputMatrix[col][row];
        }

        if (currentColSum != magicSum) {
            isMagicMatrix = false;
            return false;
        }
    }

    return true;
}

console.log(
    solve([
        [4, 5, 6],
        [6, 5, 4],
        [5, 5, 5],
    ])
);
console.log(
    solve([
        [11, 32, 45],
        [21, 0, 1],
        [21, 1, 1],
    ])
);
console.log(
    solve([
        [1, 0, 0],
        [0, 0, 1],
        [0, 1, 0],
    ])
);
