import { html, nothing } from '../lib.js';

import * as memeService from '../services/memeService.js';

const ownerBtnsTemplate = (deleteHandler, memeId) => html `
    <!-- Buttons Edit/Delete should be displayed only for creator of this meme  -->
    <a class="button warning" href="/edit/${memeId}">Edit</a>
    <button @click=${deleteHandler} class="button danger">Delete</button>
`;

const memeDetailsTemplate = (memeInfo, isOwner, deleteHandler, memeId) => html `
    <!-- Details Meme Page (for guests and logged users) -->
    <section id="meme-details">
        <h1>Meme Title: ${memeInfo.title}</h1>
        <div class="meme-details">
            <div class="meme-img">
                <img alt="meme-alt" src="${memeInfo.imageUrl}">
            </div>
            <div class="meme-description">
                <h2>Meme Description</h2>
                <p>${memeInfo.description}</p>
                ${isOwner ? ownerBtnsTemplate(deleteHandler, memeId) : nothing}
            </div>
        </div>
    </section>
`;

export function memeDetailsPage(context) {
    const memeId = context.params.memeId;

    memeService.getOne(memeId)
        .then(memeInfo => {
            let isOwner = memeInfo._ownerId === context.id;

            context.render(memeDetailsTemplate(memeInfo, isOwner, deleteHandler, memeId));
        });

    function deleteHandler(e) {
        e.preventDefault();

        if (confirm('Are you sure you want to delete this meme?')) {
            memeService.deleteMeme(memeId);
            context.page.redirect('/all-memes');
        }
    }
}