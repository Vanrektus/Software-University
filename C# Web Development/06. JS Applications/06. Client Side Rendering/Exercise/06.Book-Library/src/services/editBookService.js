import { url } from "./onClickHandlerService.js";

export function editBook(author, title, currBookId) {
    fetch(`${url}/${currBookId}`, {
        method: 'PUT',
        endpoint: `/jsonstore/books/${currBookId}`,
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            author,
            title,
        })
    });
}