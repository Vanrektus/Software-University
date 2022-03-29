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

const homeTemplate = (books) => html `
    <!-- Dashboard Page ( for Guests and Users ) -->
    <section id="dashboard-page" class="dashboard">
        <h1>Dashboard</h1>
        <!-- Display ul: with list-items for All books (If any) -->
        <ul class="other-books-list">
            ${books.length > 0 ? html`${books.map(x => bookCardTemplate(x))}` : html`<p class="no-books">No books in database!</p>`}
        </ul>
    </section>
`;

export function homePage(context) {
    bookService.getAll()
        .then(books => {
            let homeTemplateResult = homeTemplate(books);

            context.render(homeTemplateResult);
        });
}