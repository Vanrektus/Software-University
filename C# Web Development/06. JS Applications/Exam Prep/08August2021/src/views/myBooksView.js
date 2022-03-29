import { html } from '../lib.js';

import * as bookService from '../services/bookService.js';

const bookCardTemplate = (book) => html `
    <li class="otherBooks">
        <h3>${book.title}</h3>
        <p>Type: ${book.type}</p>
        <p class="img"><img src="${book.imageUrl}"></p>
        <a class="button" href="/details/${book._id}">Details</a>
    </li>
`;

const bookListTemplate = (books) => html `
    <!-- My Books Page ( Only for logged-in users ) -->
    <section id="my-books-page" class="my-books">
        <h1>My Books</h1>
        <!-- Display ul: with list-items for every user's books (if any) -->
        <ul class="my-books-list">
            ${books.length > 0 ? html`${books.map(x => bookCardTemplate(x))}` : html`<p class="no-books">No books in database!</p>`}
        </ul>
    </section>
`;

export function myBooksPage(context) {
    bookService.getOnlyOwner(context.id)
        .then(books => {
            let bookListTemplateResult = bookListTemplate(books);

            context.render(bookListTemplateResult);
        })
}