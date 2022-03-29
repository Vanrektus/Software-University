import { html } from '../lib.js';
import * as bookService from '../services/bookService.js';
import * as authServices from '../services/authService.js';

const createBookTemplate = (onSubmit) => html `
    <!-- Create Page ( Only for logged-in users ) -->
    <section id="create-page" class="create">
        <form id="create-form" action="" method="" @submit=${onSubmit}>
            <fieldset>
                <legend>Add new Book</legend>
                <p class="field">
                    <label for="title">Title</label>
                    <span class="input">
                        <input type="text" name="title" id="title" placeholder="Title">
                    </span>
                </p>
                <p class="field">
                    <label for="description">Description</label>
                    <span class="input">
                        <textarea name="description" id="description" placeholder="Description"></textarea>
                    </span>
                </p>
                <p class="field">
                    <label for="image">Image</label>
                    <span class="input">
                        <input type="text" name="imageUrl" id="image" placeholder="Image">
                    </span>
                </p>
                <p class="field">
                    <label for="type">Type</label>
                    <span class="input">
                        <select id="type" name="type">
                            <option value="Fiction">Fiction</option>
                            <option value="Romance">Romance</option>
                            <option value="Mistery">Mistery</option>
                            <option value="Classic">Clasic</option>
                            <option value="Other">Other</option>
                        </select>
                    </span>
                </p>
                <input class="button submit" type="submit" value="Add Book">
            </fieldset>
        </form>
    </section>
`;

export function createBookPage(context) {
    let createBookTemplateResult = createBookTemplate(onSubmit);

    context.render(createBookTemplateResult);

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

        bookService.createBook(bookInfo)
            .then(() => {
                context.page.redirect('/');
            });
    }
}