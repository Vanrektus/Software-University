import { html } from '../lib.js';

import * as gameService from '../services/gameService.js';

const gameCardTemplate = (game) => html `
    <div class="allGames">
        <div class="allGames-info">
            <img src="${game.imageUrl}">
            <h6>${game.category}</h6>
            <h2>${game.title}</h2>
            <a href="/details/${game._id}" class="details-button">Details</a>
        </div>

    </div>
`;

const allGamesTemplate = (games) => html `
        <!-- Catalogue -->
        <section id="catalog-page">
            <h1>All Games</h1>
            <!-- Display div: with information about every game (if any) -->
            ${games.length > 0 ? html`${games.map(x => gameCardTemplate(x))}` : html`<h3 class="no-articles">No articles yet</h3>`}
        </section>
`;

export function allGamesPage(context) {
    gameService.getAll()
        .then(games => {
            let homeTemplateResult = allGamesTemplate(games);

            context.render(homeTemplateResult);
        });
}