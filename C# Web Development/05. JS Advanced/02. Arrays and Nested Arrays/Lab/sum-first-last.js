function solve(input) {
    let firstElement = Number(input[0]);
    let lastElement = Number(input[input.length - 1]);

    let firstLastSum = firstElement + lastElement;

    console.log(firstLastSum);
}

solve(['20', '30', '40']);
solve(['5', '10']);