function solve(array, command) {
    const sort = {
        'asc': () => array.sort((a, b) => a - b),
        'desc': () => array.sort((a, b) => b - a),
    };

    return sort[command]();
}

// function solve(array, command) {
//     if (command === 'asc') {
//         return array.sort((a, b) => a - b);
//     } else {
//         return array.sort((a, b) => b - a);
//     }
// }

console.log(solve([14, 7, 17, 6, 8], 'asc'));
console.log(solve([14, 7, 17, 6, 8], 'desc'));