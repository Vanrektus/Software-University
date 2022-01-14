function solve(inputObj) {
    const resultCar = {};
    let engines = [
        { power: 90, volume: 1800 },
        { power: 120, volume: 2400 },
        { power: 200, volume: 3500 },
    ];
    let wheelsSize =
        inputObj.wheelsize % 2 == 0
            ? inputObj.wheelsize - 1
            : inputObj.wheelsize;

    resultCar.model = inputObj.model;
    resultCar.engine = engines.filter((x) => x.power >= inputObj.power)[0];
    resultCar.carriage = { type: inputObj.carriage, color: inputObj.color };
    resultCar.wheels = [wheelsSize, wheelsSize, wheelsSize, wheelsSize];

    return resultCar;
}

console.log(
    solve({
        model: "VW Golf II",
        power: 90,
        color: "blue",
        carriage: "hatchback",
        wheelsize: 14,
    })
);
console.log(
    solve({
        model: "Opel Vectra",
        power: 110,
        color: "grey",
        carriage: "coupe",
        wheelsize: 17,
    })
);
