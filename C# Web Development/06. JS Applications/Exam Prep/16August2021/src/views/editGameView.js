import { html } from '../lib.js';
import * as gameService from '../services/gameService.js';

const editGameTemplate = (game, onSubmit) => html `
    <!-- Edit Page ( Only for the creator )-->
    <section id="edit-page" class="auth">
        <form id="edit" @submit=${onSubmit}>
            <div class="container">

                <h1>Edit Game</h1>
                <label for="leg-title">Legendary title:</label>
                <input type="text" id="title" name="title" value="${game.title}">

                <label for="category">Category:</label>
                <input type="text" id="category" name="category" value="${game.category}">

                <label for="levels">MaxLevel:</label>
                <input type="number" id="maxLevel" name="maxLevel" min="1" value="${game.maxLevel}">

                <label for="game-img">Image:</label>
                <input type="text" id="imageUrl" name="imageUrl" value="${game.imageUrl}">

                <label for="summary">Summary:</label>
                <textarea name="summary" id="summary">${game.summary}</textarea>
                <input class="btn submit" type="submit" value="Edit Game">s

            </div>
        </form>
    </section>
`;

export function editGamePage(context) {
    const gameId = context.params.gameId;

    gameService.getOne(gameId)
        .then(gameInfo => {
            let editGameTemplateResult = editGameTemplate(gameInfo, onSubmit);

            context.render(editGameTemplateResult);
        });

    function onSubmit(e) {
        e.preventDefault();

        let gameDataInput = Object.fromEntries(new FormData(e.currentTarget));

        if (!(gameDataInput.title &&
                gameDataInput.category &&
                gameDataInput.maxLevel &&
                gameDataInput.imageUrl &&
                gameDataInput.summary)) {
            alert('All fields must be filled!');
            return;
        }

        let gameInfo = {
            title: gameDataInput.title,
            category: gameDataInput.category,
            maxLevel: gameDataInput.maxLevel,
            imageUrl: gameDataInput.imageUrl,
            summary: gameDataInput.summary,
        }

        gameService.editGame(gameId, gameInfo)
            .then(() => {
                context.page.redirect(`/details/${gameId}`);
            });
    }
}