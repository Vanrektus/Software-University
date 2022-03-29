import { html, nothing } from '../lib.js';

import * as bookService from '../services/bookService.js';

const ownerBtnsTemplate = (deleteHandler, bookId) => html `
    <!-- Edit/Delete buttons ( Only for creator of this book )  -->
    <a class="button" href="/edit/${bookId}">Edit</a>
    <a @click=${deleteHandler} class="button" href="#">Delete</a>
`;

const bookDetailsTemplate = (bookInfo, isOwner, deleteHandler, bookId, isAuthenticated, onLikeClick, bookLikes, hasUserLiked) => html `
        <!-- Details Page ( for Guests and Users ) -->
        <section id="details-page" class="details">
            <div class="book-information">
                <h3>${bookInfo.title}</h3>
                <p class="type">Type: ${bookInfo.type}</p>
                <p class="img"><img src="${bookInfo.imageUrl}"></p>
                <div class="actions">
                    ${isOwner ? ownerBtnsTemplate(deleteHandler, bookId) : nothing}

                    <!-- Bonus -->
                    <!-- Like button ( Only for logged-in users, which is not creators of the current book ) -->
                    ${isAuthenticated && !isOwner && !hasUserLiked ? html`<a class="button" href="#" @click=${onLikeClick}>Like</a>` : nothing}

                    <!-- ( for Guests and Users )  -->
                    <div class="likes">
                        <img class="hearts" src="/images/heart.png">
                        <span id="total-likes">Likes: ${bookLikes}</span>
                    </div>
                    <!-- Bonus -->
                </div>
            </div>
            <div class="book-description">
                <h3>Description:</h3>
                <p>${bookInfo.description}</p>
            </div>
        </section>
`;

export async function bookDetailsPage(context) {
    const bookId = context.params.bookId;

    // let bookInfo = await bookService.getOne(bookId);
    // let isOwner = bookInfo._ownerId === context.id;
    // let numOfLikes = await bookService.getBookLikes(bookId);
    // let hasUserLiked = await bookService.specificUserLikes(bookId, context.id) > 0;

    // context.render(bookDetailsTemplate(bookInfo, isOwner, deleteHandler, bookId, context.isAuthenticated, onLikeClick, numOfLikes, hasUserLiked));

    bookService.getOne(bookId)
        .then(bookInfo => {
            let isOwner = bookInfo._ownerId === context.id;

            bookService.getBookLikes(bookId)
            .then(likes => {

                bookService.specificUserLikes(bookId, context.id)
                    .then((userLikes) => {
                        let hasUserLiked = userLikes > 0;
                        context.render(bookDetailsTemplate(bookInfo, isOwner, deleteHandler, bookId, context.isAuthenticated, onLikeClick, likes, hasUserLiked));
                    });
            });
        });

    function deleteHandler(e) {
        e.preventDefault();

        if (confirm('Are you sure you want to delete this book?')) {
            bookService.deleteBook(bookId);
            context.page.redirect('/');
        }
    }
            
    function onLikeClick(e) {
        e.preventDefault();

        bookService.likeABook(bookId);

        context.page.redirect(`/details/${bookId}`);
    }
}