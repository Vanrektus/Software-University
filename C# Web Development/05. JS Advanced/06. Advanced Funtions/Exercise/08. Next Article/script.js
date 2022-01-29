function solve() {
    let inputElements = document.querySelectorAll('#container');
    let inputNameElement = inputElements[0];
    let inputHallElement = inputElements[1];
    let inputPriceElement = inputElements[2];
    let buttonsElements = document.querySelectorAll('button');
    let onScreenButtonElement = buttonsElements[0];
    let clearButtonElement = buttonsElements[1];

    onScreenButtonElement.addEventListener('click', (e) => {
        if (inputNameElement.value || inputHallElement.value || inputPriceElement.value || !isNaN(Number(inputPriceElement.value))) {
            console.log('asd');
        }
    });
}