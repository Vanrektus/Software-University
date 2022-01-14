function solve(inputArr) {
    const resultArr = [];

    for (const currHero of inputArr) {
        let [name, level, items] = currHero.split(" / ");

        const newHero = {
            name,
            level: Number(level),
            items: items ? items.split(", ") : [],
        };

        resultArr.push(newHero);
    }

    let returnJSON = JSON.stringify(resultArr);

    return returnJSON;
}

console.log(
    solve([
        "Isacc / 25 / Apple, GravityGun",
        "Derek / 12 / BarrelVest, DestructionSword",
        "Hes / 1 / Desolator, Sentinel, Antara",
    ])
);
console.log(solve(["Jake / 1000 / Gauss, HolidayGrenade"]));
console.log(solve(["Jake / 1000"]));
