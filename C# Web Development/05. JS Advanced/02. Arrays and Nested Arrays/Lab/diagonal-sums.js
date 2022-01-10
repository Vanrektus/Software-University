function solve(input) {
    let firstDiagonal = 0;
    let secondDiagonal = 0;

    for (let i = 0; i < input.length; i++) {
        firstDiagonal += Number(input[i][i]);
        secondDiagonal += Number(input[i][input.length - 1 - i]);
    }

    console.log(`${firstDiagonal} ${secondDiagonal}`);
}

solve([
    [20, 40],
    [10, 60],
]);
solve([
    [3, 5, 17],
    [-1, 7, 14],
    [1, -8, 89],
]);
