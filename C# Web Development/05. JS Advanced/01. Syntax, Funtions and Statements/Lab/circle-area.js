function solve(input) {
    if (typeof(input) === 'number') {
        console.log((input * input * Math.PI).toFixed(2));
    }
    else {
        console.log(`We can not calculate the circle area, because we receive a ${typeof(input)}.`);
    }
}

function solveBetter(input) {
    let result;
    let inputType = typeof (input);

    if (inputType === 'number') {
        result = Math.pow(input, 2) * Math.PI;

        console.log(result.toFixed(2));
    }
    else {
        console.log(`We can not calculate the circle area, because we receive a ${typeof(input)}.`);
    }
}