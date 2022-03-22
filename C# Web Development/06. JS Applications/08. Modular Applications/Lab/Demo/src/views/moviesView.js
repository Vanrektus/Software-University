import { html } from '../lib.js';
import { isAuthenticated, getUserData } from '../services/authService.js';

import * as movieService from '../services/movieService.js';

const movieCardTemplate = (movie) => html `
    <div class="movie-list-item" style="width: 18rem;">
        <img src="${movie.img}" class="card-img-top" alt="${movie.title}">
        <div class="card-body">
            <h5 class="card-title">${movie.title}</h5>
            <a href="movies/${movie._id}" class="btn btn-primary">Details</a>
        </div>
    </div>
`;

const movieListTemplate = (movies, pageTitle, movieSearchTitle) => html `
    <h3>${pageTitle}</h3>

    <div id="search-movie">
        <label for="search-by-title" class="search-movie-label">Search by name: </label>
        <input type="text" class="" id="search-by-title" placeholder="Movie Name">
        <a class="btn btn-primary" href="/movies/?search/${movieSearchTitle}" role="button">Search</a>
    </div>

    <ul class="movie-list">
        ${movies.map(x => movieCardTemplate(x))}
    </ul>
`;

export function moviesPage(context) {
    movieService.getAll()
        .then(movies => {
            let userData = getUserData();
            let filteredMovies = movies;
            let pageTitle = 'Movies Page';

            if (context.path === '/my-movies') {
                filteredMovies = movies.filter(x => x._ownerId === userData.id);
                pageTitle = 'My Movies Page';
            }

            let movieListTemplateResult = movieListTemplate(filteredMovies, pageTitle);

            context.render(movieListTemplateResult);
        });
}