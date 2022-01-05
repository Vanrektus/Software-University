function solve(a, b, operation) {
    let result;

    switch (operation) {
        case '+':
            result = a + b;
            break;

        case '-':
            result = a - b;
            break;

        case '*':
            result = a * b;
            break;

        case '/':
            result = a / b;
            break;

        case '%':
            result = a % b;
            break;

        case '**':
            result = a ** b;
            break;

        default:
            break;
    }

    console.log(result);
}

solve(1, 5, '+');