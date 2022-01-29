function solve(number) {
    let sum = number;

    function add(number2) {
        sum += number2;
        return add;
    }

    add.toString = () => {
        return sum;
    }

    return add;
}

console.log(solve(1).toString());
console.log(solve(1)(6)(-3).toString());
console.log(solve(4)(3).toString());