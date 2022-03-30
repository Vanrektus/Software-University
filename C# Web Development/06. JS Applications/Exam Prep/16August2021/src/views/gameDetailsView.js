import { html, nothing } from '../lib.js';

import * as gameService from '../services/gameService.js';

const ownerBtnsTemplate = (deleteHandler, gameId) => html `
    <!-- Edit/Delete buttons ( Only for creator of this game )  -->
    <div class="buttons">
        <a href="/edit/${gameId}" class="button">Edit</a>
        <a @click=${deleteHandler} href="#" class="button">Delete</a>
    </div>
`;

const commentCardTemplate = (comment) => html `
    <li class="comment">
        <p>${comment}</p>
    </li>
`;

const userAddCommentTemplate = (onSubmit) => html `
    <!-- Add Comment ( Only for logged-in users, which is not creators of the current game ) -->
    <article class="create-comment">
        <label>Add new comment:</label>
        <form class="form" @submit=${onSubmit}>
            <textarea name="comment" placeholder="Comment......"></textarea>
            <input class="btn submit" type="submit" value="Add Comment">
        </form>
    </article>
`;

const gameDetailsTemplate = (gameInfo, isOwner, deleteHandler, gameId, comments, onSubmit, isAuthenticated) => html `
    <!--Details Page-->
    <section id="game-details">
        <h1>Game Details</h1>
        <div class="info-section">

            <div class="game-header">
                <img class="game-img" src="${gameInfo.imageUrl}" />
                <h1>${gameInfo.title}</h1>
                <span class="levels">MaxLevel: ${gameInfo.maxLevel}</span>
                <p class="type">${gameInfo.category}</p>
            </div>

            <p class="text">${gameInfo.summary}</p>

            <!-- Bonus ( for Guests and Users ) -->
            <div class="details-comments">
                <h2>Comments:</h2>
                <ul>
                    <!-- list all comments for current game (If any) -->
                    ${comments.length > 0 ? html`${comments.map(x => commentCardTemplate(x.comment))}` : html`<p class="no-comment">No comments.</p>`}
                </ul>
            </div>

            <!-- Edit/Delete buttons ( Only for creator of this game )  -->
            <div class="buttons">
                ${isOwner ? ownerBtnsTemplate(deleteHandler, gameId) : nothing}
            </div>
        </div>

        <!-- Bonus -->
        <!-- Add Comment ( Only for logged-in users, which is not creators of the current game ) -->
        ${isAuthenticated && !isOwner ? html`${userAddCommentTemplate(onSubmit)}` : nothing}

    </section>
`;

export async function gameDetailsPage(context) {
    const gameId = context.params.gameId;

    gameService.getOne(gameId)
        .then(gameInfo => {
            let isOwner = gameInfo._ownerId === context.id;

            gameService.getAllComments(gameId)
                .then(comments => {
                    context.render(gameDetailsTemplate(gameInfo, isOwner, deleteHandler, gameId, comments, onSubmit, context.isAuthenticated));
                });
        });

    function deleteHandler(e) {
        e.preventDefault();

        if (confirm('Are you sure you want to delete this game?')) {
            gameService.deleteGame(gameId);
            context.page.redirect('/');
        }
    }

    function onSubmit(e) {
        e.preventDefault();

        let commentDataInput = Object.fromEntries(new FormData(e.currentTarget));

        console.log(commentDataInput.comment);

        if (!commentDataInput.comment) {
            alert('All fields must be filled!');
            return;
        }

        let commentInfo = {
            gameId,
            comment: commentDataInput.comment,
        };

        gameService.commentGame(commentInfo)
        .then(() => {
            e.target.reset();
            context.page.redirect(`/details/${gameId}`);
        });
    }
}