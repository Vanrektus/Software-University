function addItem() {
    let dropdownMenuElement = document.querySelector('#menu');
    let inputTextElement = document.querySelector('#newItemText');
    let inputValueElement = document.querySelector('#newItemValue');

    let newOptionElement = document.createElement('option');
    newOptionElement.textContent = inputTextElement.value;
    newOptionElement.value = inputValueElement.value;

    dropdownMenuElement.appendChild(newOptionElement);

    inputTextElement.value = '';
    inputValueElement.value = '';
}