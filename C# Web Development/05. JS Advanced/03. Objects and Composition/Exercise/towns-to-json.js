function solve(inputArr) {
    const resultArr = [];

    for (const currTown of inputArr) {
        let arrSplit = currTown.split("|");
        let townName = arrSplit[1].trim();
        let latitude =
            Math.round((Number(arrSplit[2]) + Number.EPSILON) * 100) / 100;
        let longitude =
            Math.round((Number(arrSplit[3]) + Number.EPSILON) * 100) / 100;

        const newTown = {
            Town: townName,
            Latitude: latitude,
            Longitude: longitude,
        };

        if (newTown.Town != "Town") {
            resultArr.push(newTown);
        }
    }

    let resultJSON = JSON.stringify(resultArr);

    return resultJSON;
}

console.log(
    solve([
        "| Town | Latitude | Longitude |",
        "| Sofia | 42.696552 | 23.32601 |",
        "| Beijing | 39.913818 | 116.363625 |",
    ])
);
console.log(
    solve([
        "| Town | Latitude | Longitude |",
        "| Veliko Turnovo | 43.0757 | 25.6172 |",
        "| Monatevideo | 34.50 | 56.11 |",
    ])
);
