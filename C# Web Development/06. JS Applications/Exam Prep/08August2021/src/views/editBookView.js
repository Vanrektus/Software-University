import { html } from '../lib.js';
import * as bookService from '../services/bookService.js';

const editBookTemplate = (book, onSubmit) => html `
    <!-- Edit Page ( Only for the creator )-->
    <section id="edit-page" class="edit">
        <form id="edit-form" action="#" method="" @submit=${onSubmit}>
            <fieldset>
                <legend>Edit my Book</legend>
                <p class="field">
                    <label for="title">Title</label>
                    <span class="input">
                        <input type="text" name="title" id="title" value="${book.title}">
                    </span>
                </p>
                <p class="field">
                    <label for="description">Description</label>
                    <span class="input">
                        <textarea name="description" id="description">${book.description}</textarea>
                    </span>
                </p>
                <p class="field">
                    <label for="image">Image</label>
                    <span class="input">
                        <input type="text" name="imageUrl" id="image" value="${book.imageUrl}">
                    </span>
                </p>
                <p class="field">
                    <label for="type">Type</label>
                    <span class="input">
                        <select id="type" name="type" value="${book.type}">
                            <option value="Fiction" selected>Fiction</option>
                            <option value="Romance">Romance</option>
                            <option value="Mistery">Mistery</option>
                            <option value="Classic">Clasic</option>
                            <option value="Other">Other</option>
                        </select>
                    </span>
                </p>
                <input class="button submit" type="submit" value="Save">
            </fieldset>
        </form>
    </section>
`;

export function editBookPage(context) {
    const bookId = context.params.bookId;

    bookService.getOne(bookId)
        .then(bookInfo => {
            let editBookTemplateResult = editBookTemplate(bookInfo, onSubmit);

            context.render(editBookTemplateResult);
        });

    function onSubmit(e) {
        e.preventDefault();

        let bookDataInput = Object.fromEntries(new FormData(e.currentTarget));

        if (!(bookDataInput.title &&
                bookDataInput.description &&
                bookDataInput.imageUrl)) {
            alert('All fields must be filled!');
            return;
        }

        let bookInfo = {
            title: bookDataInput.title,
            description: bookDataInput.description,
            imageUrl: bookDataInput.imageUrl,
            type: bookDataInput.type,
        }

        bookService.editBook(bookId, bookInfo)
            .then(() => {
                context.page.redirect(`/details/${bookId}`);
            });
    }
}