import { html, nothing } from '../lib.js';

import * as movieService from '../services/movieService.js';

const loggedUserBtnsTemplate = (deleteHandler, movieId) => html `
    <a href="/edit/${movieId}" class="btn btn-primary">Edit</a>
    <a @click=${deleteHandler} href="" class="btn btn-primary">Delete</a>
`;

const movieDetailsTemplate = (movie, isAuthor, deleteHandler, movieId) => html `
    <h3>Details Page</h3>

    <div class="movie-details" style="width: 18rem;">
        <img src="${movie.img}" class="card-img-top" alt="${movie.title}">
        <div class="card-body">
            <h5 class="card-title">${movie.title}</h5>
            <p class="card-text">${movie.description}</p>
            ${isAuthor ? loggedUserBtnsTemplate(deleteHandler, movieId) : nothing}
        </div>
    </div>
`;

export function movieDetailsPage(context) {
    const movieId = context.params.movieId;

    movieService.getOne(movieId)
        .then(movieData => {
            let isAuthor = movieData._ownerId === context.id;

            context.render(movieDetailsTemplate(movieData, isAuthor, deleteHandler, movieId));
        });

    function deleteHandler(e) {
        e.preventDefault();

        if (confirm('Are you sure you want to delete this movie?')) {
            movieService.deleteMovie(movieId);
            context.page.redirect('/movies');
        }
    }
}