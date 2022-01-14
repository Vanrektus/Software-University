function solve(inputArray) {
    const result = {};

    for (let i = 0; i < inputArray.length; i += 2) {
        result[inputArray[i]] = Number(inputArray[i + 1]);
    }

    console.log(result);
}

solve(["Yoghurt", "48", "Rise", "138", "Apple", "52"]);
solve(["Potato", "93", "Skyr", "63", "Cucumber", "18", "Milk", "42"]);
