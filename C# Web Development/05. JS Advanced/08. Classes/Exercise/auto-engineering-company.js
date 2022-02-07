function solve(inputArr) {
    let cars = new Map();

    for (const currCar of inputArr) {
        let [brand, model, amount] = currCar.split(' | ');

        if (!cars.has(brand)) {
            cars.set(brand, new Map([
                [model, 0]
            ]));
        }

        cars.get(brand).set(model, (cars.get(brand).get(model) || 0) + Number(amount));
    }

    for (const [brand, allModelsOfCurrBrand] of cars) {
        console.log(brand);

        for (const [model, amount] of allModelsOfCurrBrand) {
            console.log(`###${model} -> ${amount}`);
        }
    }
}

solve(['Audi | Q7 | 1000',
    'Audi | Q6 | 100',
    'BMW | X5 | 1000',
    'BMW | X6 | 100',
    'Citroen | C4 | 123',
    'Volga | GAZ-24 | 1000000',
    'Lada | Niva | 1000000',
    'Lada | Jigula | 1000000',
    'Citroen | C4 | 22',
    'Citroen | C5 | 10'
]);