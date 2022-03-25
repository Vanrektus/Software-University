import { html } from '../lib.js';

import * as memeService from '../services/memeService.js';

const memeCardTemplate = (meme) => html `
    <!-- Display : All memes in database ( If any ) -->
    <div class="meme">
        <div class="card">
            <div class="info">
                <p class="meme-title">${meme.title}</p>
                <img class="meme-image" alt="meme-img" src="${meme.imageUrl}">
            </div>
            <div id="data-buttons">
                <a class="button" href="/details/${meme._id}">Details</a>
            </div>
        </div>
    </div>
`;

const memeListTemplate = (memes) => html `
    <!-- All Memes Page ( for Guests and Users )-->
    <section id="meme-feed">
        <h1>All Memes</h1>
        <div id="memes">
            ${memes.length > 0 ? html`${memes.map(x => memeCardTemplate(x))}` : html`<p class="no-memes">No memes in database.</p>`}
        </div>
    </section>
`;

export function allMemesPage(context) {
    memeService.getAll()
        .then(memes => {
            let filteredMemes = memes;

            let memeListTemplateResult = memeListTemplate(filteredMemes);

            context.render(memeListTemplateResult);
        })
}