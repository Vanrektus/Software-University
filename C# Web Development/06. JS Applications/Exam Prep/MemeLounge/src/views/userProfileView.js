import { html } from '../lib.js';

import * as memeService from '../services/memeService.js';

const memeCardTemplate = (meme) => html `
    <!-- Display : All memes in database ( If any ) -->
    <div class="user-meme">
        <p class="user-meme-title">${meme.title}</p>
        <img class="userProfileImage" alt="meme-img" src="${meme.imageUrl}">
        <a class="button" href="/details/${meme._id}">Details</a>
    </div>
`;

const memeListTemplate = (memes, username, email, gender) => html `
    <!-- Profile Page ( Only for logged users ) -->
    <section id="user-profile-page" class="user-profile">
        <article class="user-info">
            <img id="user-avatar-url" alt="user-profile" src="/images/female.png" src="${gender ===  'male' ? '/images/male.png' : '/images/female.png'}">
            <div class="user-content">
                <p>Username: ${username}</p>
                <p>Email: ${email}</p>
                <p>My memes count: ${memes.length}</p>
            </div>
        </article>
        <h1 id="user-listings-title">User Memes</h1>
        <div class="user-meme-listings">
            <!-- Display : All created memes by this user (If any) -->
            ${memes.length > 0 ? html`${memes.map(x => memeCardTemplate(x))}` : html`<p class="no-memes">No memes in database.</p>`}
        </div>
    </section>
`;

export function userProfilePage(context) {
    memeService.getOnlyOwner(context.id)
        .then(memes => {
            console.log(memes);
            let filteredMemes = memes;

            let memeListTemplateResult = memeListTemplate(filteredMemes, context.username, context.email, context.gender);

            context.render(memeListTemplateResult);
        })
}