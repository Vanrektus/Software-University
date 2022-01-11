function solve(inputArray) {
    inputArray
        .sort((a, b) => a.localeCompare(b))
        .forEach((currentName, i) => {
            console.log(`${i + 1}.${currentName}`);
        });
}

solve(["John", "Bob", "Christina", "Ema"]);
