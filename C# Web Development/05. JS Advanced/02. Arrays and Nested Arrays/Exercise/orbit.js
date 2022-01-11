function solve(inputMatrix) {
    let rows = inputMatrix[0];
    let cols = inputMatrix[1];
    let initRow = inputMatrix[2];
    let initCol = inputMatrix[3];

    let matrix = [];

    for (let row = 0; row < rows; row++) {
        matrix[row] = [];

        for (let col = 0; col < cols; col++) {
            matrix[row][col] =
                Math.max(Math.abs(row - initRow), Math.abs(col - initCol)) + 1;
        }
    }

    console.log(matrix.map((x) => x.join(" ")).join("\n"));
}

solve([4, 4, 0, 0]);
solve([5, 5, 2, 2]);
solve([3, 3, 2, 2]);
