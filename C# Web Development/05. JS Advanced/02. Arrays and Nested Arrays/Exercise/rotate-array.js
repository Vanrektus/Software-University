function solve(inputArray, numberOfRotations) {
    debugger;

    for (let i = 0; i < numberOfRotations; i++) {
        inputArray.unshift(inputArray.pop());
    }

    console.log(inputArray.join(" "));
}

solve(["1", "2", "3", "4"], 2);
solve(["Banana", "Orange", "Coconut", "Apple"], 15);
