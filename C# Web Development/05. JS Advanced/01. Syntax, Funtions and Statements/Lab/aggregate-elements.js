function solve(elements) {
    aggregate(elements, 0, (a, b) => a + b);
    aggregate(elements, 0, (a, b) => a + 1 / b);
    aggregate(elements, '', (a, b) => a + b);

    function aggregate(array, initVal, func) {
        let val = initVal;

        for (let i = 0; i < array.length; i++) {
            val = func(val, array[i]);
        }
        
        console.log(val);
    }
}

solve([1, 2, 4]);