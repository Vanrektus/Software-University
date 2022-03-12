import { url } from "./onClickHandlerService.js";

export function addBook(author, title) {
    fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            author,
            title,
        })
    });
}