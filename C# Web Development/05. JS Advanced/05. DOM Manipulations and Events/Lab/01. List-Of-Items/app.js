function addItem() {
    let inputElement = document.querySelector('#newItemText');
    let itemsElement = document.querySelector('#items');

    let newItemElement = document.createElement('li');
    newItemElement.textContent = inputElement.value;
    itemsElement.appendChild(newItemElement);

    inputElement.value = '';
}