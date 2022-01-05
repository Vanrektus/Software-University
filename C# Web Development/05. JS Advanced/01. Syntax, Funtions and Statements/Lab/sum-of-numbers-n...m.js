function solve(a, b) {
    let num1 = Number(a);
    let num2 = Number(b);
    let result = 0;

    for (let index = num1; index <= num2; index++) {
        result += index;
    }

    return result;
}
