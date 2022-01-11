function solve(inputArray) {
    let resultArray = [];

    for (let i = 0; i < inputArray.length; i++) {
        if (inputArray[i] == "add") {
            resultArray.push(i + 1);
        } else if (inputArray[i] == "remove") {
            resultArray.pop();
        }
    }

    if (resultArray.length > 0) {
        console.log(resultArray.join("\r\n"));
    } else {
        console.log("Empty");
    }
}

solve(["add", "add", "add", "add"]);
solve(["add", "add", "remove", "add", "add"]);
solve(["remove", "remove", "remove"]);
