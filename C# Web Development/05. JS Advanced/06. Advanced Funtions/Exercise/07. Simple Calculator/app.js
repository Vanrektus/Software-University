function calculator() {
    let firstInputElement;
    let secondInputElement;
    let resultElement;

    return {
        init(firstSelector, secondSelector, resultSelector) {
            firstInputElement = document.querySelector(firstSelector);
            secondInputElement = document.querySelector(secondSelector);
            resultElement = document.querySelector(resultSelector);
        },
        add() {
            resultElement.value = Number(firstInputElement.value) + Number(secondInputElement.value);
        },
        subtract() {
            resultElement.value = Number(firstInputElement.value) - Number(secondInputElement.value);
        },
    }
}

const calculate = calculator();
calculate.init('#num1', '#num2', '#result');