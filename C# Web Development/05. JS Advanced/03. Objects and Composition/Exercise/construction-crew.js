function solve(inputObj) {
    if (inputObj.dizziness == true) {
        inputObj.levelOfHydrated += 0.1 * inputObj.weight * inputObj.experience;
        inputObj.dizziness = false;
    }

    return inputObj;
}

console.log(
    solve({ weight: 80, experience: 1, levelOfHydrated: 0, dizziness: true })
);
console.log(
    solve({
        weight: 120,
        experience: 20,
        levelOfHydrated: 200,
        dizziness: true,
    })
);
console.log(
    solve({ weight: 95, experience: 3, levelOfHydrated: 0, dizziness: false })
);
