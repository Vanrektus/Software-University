function solve(a) {
    if (typeof (a) === 'number') {
        for (let index = 0; index < a; index++) {
            console.log('* '.repeat(a));
        }
    }
    else {
        for (let index = 0; index < 5; index++) {
            console.log('* '.repeat(5));
        }
    }
}

solve(7);