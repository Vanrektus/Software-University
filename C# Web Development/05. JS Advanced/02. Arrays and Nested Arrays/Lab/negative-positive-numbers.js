function solve(input) {
    for (let i = 0; i < input.length; i++) {
        if (input[i] < 0) {
            let elementToMove = Number(input.splice(i, 1));
            input.unshift(elementToMove);
        }        
    }

    console.log(input);
}

solve([7, -2, 8, 9]);
solve([3, -2, 0, -1]);