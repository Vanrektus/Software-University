import { html } from '../lib.js';
import * as memeServices from '../services/memeService.js';
import * as authServices from '../services/authService.js';

const editMemeTemplate = (meme, onSubmit) => html `
    <!-- Edit Meme Page ( Only for logged user and creator to this meme )-->
    <section id="edit-meme">
        <form id="edit-form" @submit=${onSubmit}>
            <h1>Edit Meme</h1>
            <div class="container">
                <label for="title">Title</label>
                <input id="title" type="text" placeholder="Enter Title" name="title" value=${meme.title}>
                <label for="description">Description</label>
                <textarea id="description" placeholder="Enter Description" name="description">${meme.description}</textarea>
                <label for="imageUrl">Image Url</label>
                <input id="imageUrl" type="text" placeholder="Enter Meme ImageUrl" name="imageUrl" value="${meme.imageUrl}">
                <input type="submit" class="registerbtn button" value="Edit Meme">
            </div>
        </form>
    </section>
`;

export function editMemePage(context) {
    const memeId = context.params.memeId;

    memeServices.getOne(memeId)
        .then(memeInfo => {
            let editMemeTemplateResult = editMemeTemplate(memeInfo, onSubmit);

            context.render(editMemeTemplateResult);
        });

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

        memeServices.editMeme(memeId, memeInfo)
            .then(() => {
                context.page.redirect(`/details/${memeId}`);
            });
    }
}