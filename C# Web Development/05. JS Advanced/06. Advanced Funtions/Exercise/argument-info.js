function solve(...inputArray) {
    let types = {};

    for (const currArgument of inputArray) {
        console.log(`${typeof currArgument}: ${currArgument}`);
        !types[typeof currArgument] ? types[typeof currArgument] = 1 : types[typeof currArgument]++;
    }

    Object.keys(types).sort((a, b) => types[b] - types[a]).forEach(x => console.log(`${x} = ${types[x]}`));
}

solve('cat', 42, function() { console.log('Hello world!'); });