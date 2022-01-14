function solve(inputArray) {
    const resultProducts = [];

    for (const currProduct of inputArray) {
        let [town, productName, price] = currProduct.split(" | ");

        const newProduct = {
            product: productName,
            price: Number(price),
            town,
        };

        if (!resultProducts.some((x) => x.product === productName)) {
            resultProducts.push(newProduct);
        } else {
            const objFromResultArr = resultProducts.find(
                (x) => x.product === productName
            );

            if (price < objFromResultArr.price) {
                objFromResultArr.price = price;
                objFromResultArr.town = town;
            }
        }
    }

    for (const currProduct of resultProducts) {
        console.log(
            `${currProduct.product} -> ${currProduct.price} (${currProduct.town})`
        );
    }
}

solve([
    "Sample Town | Sample Product | 1000",
    "Sample Town | Orange | 2",
    "Sample Town | Peach | 1",
    "Sofia | Orange | 3",
    "Sofia | Peach | 2",
    "New York | Sample Product | 1000.1",
    "New York | Burger | 10",
]);
solve([
    "Sofia City | Audi | 100000",
    "Sofia City | BMW | 100000",
    "Sofia City | Mitsubishi | 10000",
    "Sofia City | Mercedes | 10000",
    "Sofia City | NoOffenseToCarLovers | 0",
    "Mexico City | Audi | 1000",
    "Mexico City | BMW | 99999",
    "Mexico City | Mitsubishi | 10000",
    "New York City | Mitsubishi | 1000",
    "Washington City | Mercedes | 1000",
]);
