function solve(inputNumber, op1, op2, op3, op4, op5) {
    let number = Number(inputNumber);
    let operationsArray = [op1, op2, op3, op4, op5];

    for (let i = 0; i < 5; i++) {
        let currentOperation = operationsArray[i];

        switch (currentOperation) {
            case 'chop':
                number /= 2;

                console.log(number);
                break;

            case 'dice':
                number = Math.sqrt(number);

                console.log(number);
                break;

            case 'spice':
                number++;

                console.log(number);
                break;

            case 'bake':
                number *= 3;

                console.log(number);
                break;

            case 'fillet':
                number -= number * 0.2;

                console.log(number);
                break;

            default:
                break;
        }
    }
}

// solve('32', 'chop', 'chop', 'chop', 'chop', 'chop');
// solve('9', 'dice', 'spice', 'chop', 'bake', 'fillet');

function solve2(number, op1, op2, op3, op4, op5) {

    number = applyOperation(number, op1);
    console.log(number);
    number = applyOperation(number, op2);
    console.log(number);
    number = applyOperation(number, op3);
    console.log(number);
    number = applyOperation(number, op4);
    console.log(number);
    number = applyOperation(number, op5);
    console.log(number);

    function applyOperation(number, opertaion) {
        switch (opertaion) {
            case 'chop':
                number /= 2;
                break;

            case 'dice':
                number = Math.sqrt(number);
                break;

            case 'spice':
                number++;
                break;

            case 'bake':
                number *= 3;
                break;

            case 'fillet':
                number -= number * 0.2;
                break;

            default:
                break;
        }

        return number;
    }
}

solve2('32', 'chop', 'chop', 'chop', 'chop', 'chop');
solve2('9', 'dice', 'spice', 'chop', 'bake', 'fillet');