import { url } from "./onClickHandlerService.js";

export function deleteBook(currBookId) {
    fetch(`${url}/${currBookId}`, {
        method: 'DELETE'
    });
}