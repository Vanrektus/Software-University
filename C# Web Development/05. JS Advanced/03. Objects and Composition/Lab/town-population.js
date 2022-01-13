function solve(inputArray) {
    const towns = {};

    for (let currentCity of inputArray) {
        let [name, population] = currentCity.split(" <-> ");
        population = Number(population);

        if (towns[name] == undefined) {
            towns[name] = population;
        } else {
            towns[name] += population;
        }
    }

    for (const [name, population] of Object.entries(towns)) {
        console.log(`${name} : ${population}`);
    }

    // for (let currentCity in towns) {
    //     console.log(`${currentCity} : ${towns[currentCity]}`);
    // }
}

function solve2(inputArray) {
    const towns = {};

    inputArray.forEach((currCity) => {
        let [townName, population] = currCity.split(" <-> ");
        !towns.hasOwnProperty(townName)
            ? (towns[townName] = Number(population))
            : (towns[townName] += Number(population));
    });

    Object.entries(towns).forEach((currCity) =>
        console.log(`${currCity[0]} : ${currCity[1]}`)
    );
}

solve2([
    "Istanbul <-> 100000",
    "Honk Kong <-> 2100004",
    "Jerusalem <-> 2352344",
    "Mexico City <-> 23401925",
    "Istanbul <-> 1000",
]);
solve2([
    "Sofia <-> 1200000",
    "Montana <-> 20000",
    "New York <-> 10000000",
    "Washington <-> 2345000",
    "Las Vegas <-> 1000000",
]);
