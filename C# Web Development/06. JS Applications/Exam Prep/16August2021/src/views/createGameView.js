import { html } from '../lib.js';
import * as gameService from '../services/gameService.js';

const createGameTemplate = (onSubmit) => html `
    <!-- Create Page ( Only for logged-in users ) -->
    <section id="create-page" class="auth">
        <form id="create" @submit=${onSubmit}>
            <div class="container">

                <h1>Create Game</h1>
                <label for="leg-title">Legendary title:</label>
                <input type="text" id="title" name="title" placeholder="Enter game title...">

                <label for="category">Category:</label>
                <input type="text" id="category" name="category" placeholder="Enter game category...">

                <label for="levels">MaxLevel:</label>
                <input type="number" id="maxLevel" name="maxLevel" min="1" placeholder="1">

                <label for="game-img">Image:</label>
                <input type="text" id="imageUrl" name="imageUrl" placeholder="Upload a photo...">

                <label for="summary">Summary:</label>
                <textarea name="summary" id="summary"></textarea>
                <input class="btn submit" type="submit" value="Create Game">
            </div>
        </form>
    </section>
`;

export function createGamePage(context) {
    let createGameTemplateResult = createGameTemplate(onSubmit);

    context.render(createGameTemplateResult);

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

        gameService.createGame(gameInfo)
            .then(() => {
                context.page.redirect('/');
            });
    }
}