import { html } from '../lib.js';
import * as memeServices from '../services/memeService.js';
import * as authServices from '../services/authService.js';

const createMemeTemplate = (onSubmit) => html `
    <!-- Create Meme Page ( Only for logged users ) -->
    <section id="create-meme">
        <form id="create-form" @submit=${onSubmit}>
            <div class="container">
                <h1>Create Meme</h1>
                <label for="title">Title</label>
                <input id="title" type="text" placeholder="Enter Title" name="title">
                <label for="description">Description</label>
                <textarea id="description" placeholder="Enter Description" name="description"></textarea>
                <label for="imageUrl">Meme Image</label>
                <input id="imageUrl" type="text" placeholder="Enter meme ImageUrl" name="imageUrl">
                <input type="submit" class="registerbtn button" value="Create Meme">
            </div>
        </form>
    </section>
`;

export function createMemePage(context) {
    let createMemeTemplateResult = createMemeTemplate(onSubmit);

    context.render(createMemeTemplateResult);

    function onSubmit(e) {
        e.preventDefault();

        let memeDataInput = Object.fromEntries(new FormData(e.currentTarget));

        if (!(memeDataInput.title &&
                memeDataInput.description &&
                memeDataInput.imageUrl)) {
            authServices.getNotification('All fields must be filled!');
            // alert('All fields must be filled!');
            return;
        }

        let memeInfo = {
            title: memeDataInput.title,
            description: memeDataInput.description,
            imageUrl: memeDataInput.imageUrl,
        }

        memeServices.createMeme(memeInfo)
            .then(() => {
                context.page.redirect('/all-memes');
            });
    }
}