function solve(inputMatrix) {
    let matrix = [];

    for (let row = 0; row < inputMatrix.length; row++) {
        let splitStringArray = inputMatrix[row].split(" ");
        matrix[row] = [];

        for (let col = 0; col < splitStringArray.length; col++) {
            matrix[row][col] = Number(splitStringArray[col]);
        }
    }

    let leftDiagonalSum = 0;
    let rightDiagonalSum = 0;

    for (let row = 0; row < matrix.length; row++) {
        for (let col = 0; col < matrix[row].length; col++) {
            if (row === col) {
                leftDiagonalSum += matrix[row][col];
            }

            if (row + col === matrix.length - 1) {
                rightDiagonalSum += matrix[row][col];
            }
        }
    }

    if (leftDiagonalSum === rightDiagonalSum) {
        for (let row = 0; row < matrix.length; row++) {
            for (let col = 0; col < matrix[row].length; col++) {
                if (row === col || row + col === matrix.length - 1) {
                    continue;
                }

                matrix[row][col] = leftDiagonalSum;
            }
        }
    }

    for (const row of matrix) {
        console.log(row.join(" "));
    }
}

solve([
    "5 3 12 3 1",
    "11 4 23 2 5",
    "101 12 3 21 10",
    "1 4 5 2 2",
    "5 22 33 11 1",
]);
solve(["1 1 1", "1 1 1", "1 1 0"]);
