import { html } from '../lib.js';

import * as gameService from '../services/gameService.js';

const gameCardTemplate = (game) => html `
    <!-- Display div: with information about every game (if any) -->
    <div class="game">
        <div class="image-wrap">
            <img src="${game.imageUrl}">
        </div>
        <h3>${game.title}</h3>
        <div class="rating">
            <span>☆</span><span>☆</span><span>☆</span><span>☆</span><span>☆</span>
        </div>
        <div class="data-buttons">
            <a href="/details/${game._id}" class="btn details-btn">Details</a>
        </div>
    </div>
`;

const homeTemplate = (games) => html `
    <!--Home Page-->
    <section id="welcome-world">

        <div class="welcome-message">
            <h2>ALL new games are</h2>
            <h3>Only in GamesPlay</h3>
        </div>
        <img src="./images/four_slider_img01.png" alt="hero">

        <div id="home-page">
            <h1>Latest Games</h1>
            ${games.length > 0 ? html`${games.map(x => gameCardTemplate(x))}` : html`<p class="no-articles">No games yet</p>`}
        </div>
    </section>
`;

export function homePage(context) {
    gameService.getAllSorted()
        .then(games => {
            let firstThreeGames = games.filter((x, index) => index < 3);
            let homeTemplateResult = homeTemplate(firstThreeGames);

            context.render(homeTemplateResult);
        });
}