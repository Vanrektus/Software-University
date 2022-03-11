import { renderBooks } from "./renderBooksService.js";

const url = "http://localhost:3030/jsonstore/collections/books";

export function loadFunctionality(e) {
    e.preventDefault();

    renderBooks();
}

export function addFunctionality(e) {
    e.preventDefault();

    let submitForm = new FormData(e.currentTarget.parentNode);
    let titleInput = submitForm.get('title');
    let authorInput = submitForm.get('author');

    if (!(titleInput && authorInput)) {
        return;
    }

    fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            author: authorInput,
            title: titleInput,
        })
    });

    e.currentTarget.parentNode.reset();
    renderBooks();
}

export function editFunctionality(e) {
    e.preventDefault();

    let submitFormElement = document.querySelector('#create-form');
    let editFormElement = document.querySelector('#edit-form');

    submitFormElement.setAttribute('class', 'hide');
    editFormElement.removeAttribute('class', 'hide');
}

export function deleteFunctionality(e) {
    e.preventDefault();

    let currElement = e.target.parentNode.parentNode;
    let currBookId = currElement.id;

    fetch(`${url}/${currBookId}`, {
        method: 'DELETE'
    });

    currElement.remove();
    renderBooks();
}

export function saveEditFunctionality(e) {
    e.preventDefault();
}