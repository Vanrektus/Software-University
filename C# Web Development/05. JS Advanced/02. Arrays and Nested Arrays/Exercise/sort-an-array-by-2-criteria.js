function solve(inputArray) {
    inputArray
        .sort((a, b) => a.length - b.length || a.localeCompare(b))
        .forEach((currentElement) => {
            console.log(currentElement);
        });
}

solve(["alpha", "beta", "gamma"]);
solve(["Isacc", "Theodor", "Jack", "Harrison", "George"]);
solve(["test", "Deny", "omen", "Default"]);
