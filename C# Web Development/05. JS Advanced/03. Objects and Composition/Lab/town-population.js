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

    for (let currentCity in towns) {
        console.log(`${currentCity} : ${towns[currentCity]}`);
    }
}

solve([
    "Istanbul <-> 100000",
    "Honk Kong <-> 2100004",
    "Jerusalem <-> 2352344",
    "Mexico City <-> 23401925",
    "Istanbul <-> 1000",
]);
solve([
    "Sofia <-> 1200000",
    "Montana <-> 20000",
    "New York <-> 10000000",
    "Washington <-> 2345000",
    "Las Vegas <-> 1000000",
]);
