function calc() {
    let num1 = Number(document.querySelector("#num1").value);
    let num2 = Number(document.querySelector("#num2").value);

    let sum = num1 + num2;

    let sumElement = document.querySelector("#sum");
    sumElement.value = sum;
}
