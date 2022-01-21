function addItem() {
    let newItemTextElement = document.querySelector('#newItemText');
    let itemsElement = document.querySelector('#items');

    let liItemElement = document.createElement('li');
    liItemElement.textContent = newItemTextElement.value;

    // Add delete button
    let deleteButton = document.createElement('a');
    deleteButton.setAttribute('href', '#');
    deleteButton.textContent = '[Delete]';

    // Attach event to delete button
    deleteButton.addEventListener('click', (e) => {
        e.target.parentNode.remove();
    });

    liItemElement.appendChild(deleteButton);
    itemsElement.appendChild(liItemElement);

    newItemTextElement.value = '';
}