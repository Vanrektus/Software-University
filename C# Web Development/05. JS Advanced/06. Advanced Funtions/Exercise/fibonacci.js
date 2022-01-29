function getFibonator() {
    let number1 = 0;
    let number2 = 1;

    return function() {
        let nextNumber = number1 + number2;
        number1 = number2;
        number2 = nextNumber;

        return number1;
    }
}

// function getFibonator() {
//     let number1 = 1;
//     let number2 = 1;
//     let fibonacci = 0;

//     return function() {
//         [fibonacci, number1, number2] = [number1, number2, number1 + number2];
//         return fibonacci;
//     }
// }

let fib = getFibonator();
console.log(fib()); // 1
console.log(fib()); // 1
console.log(fib()); // 2
console.log(fib()); // 3
console.log(fib()); // 5
console.log(fib()); // 8
console.log(fib()); // 13