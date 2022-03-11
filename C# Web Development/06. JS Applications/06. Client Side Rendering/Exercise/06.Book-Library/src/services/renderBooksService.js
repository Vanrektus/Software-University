import { render } from "../../../node_modules/lit-html/lit-html.js";
import { getBooks } from "./getBooksService.js";
import bookListTemplate from "../templates/bookListTemplate.js";

export function renderBooks() {
    let rootElement = document.querySelector('body');

    getBooks()
        .then(result => {
            let bookListTemplateResult = bookListTemplate(result);

            render(bookListTemplateResult, rootElement);
        })
}