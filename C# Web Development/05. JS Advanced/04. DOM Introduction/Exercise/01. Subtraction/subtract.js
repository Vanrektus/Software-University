function subtract() {
    let num1 = Number(document.querySelector("#firstNumber").value);
    let num2 = Number(document.querySelector("#secondNumber").value);

    let sum = num1 - num2;

    let sumElement = document.querySelector("#result");
    sumElement.textContent = sum;

    //console.log(sum);
}
