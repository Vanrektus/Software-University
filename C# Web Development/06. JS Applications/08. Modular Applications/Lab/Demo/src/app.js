import { page } from './lib.js';

import { renderMiddleware } from './middlewares/renderMiddleware.js';
import { authMiddleware } from './middlewares/authMiddleware.js';
import { homePage } from './views/homeView.js';
import { registerPage } from './views/registerView.js';
import { loginPage } from './views/loginView.js';
import { logoutPage } from './views/logoutView.js';
import { moviesPage } from './views/moviesView.js';
import { movieDetailsPage } from './views/movieDetailsView.js';
import { addMoviePage } from './views/addMovieView.js';
import { editMoviePage } from './views/editMovieView.js';

page(authMiddleware);
page(renderMiddleware);

page('/', homePage);
page('/register', registerPage);
page('/login', loginPage);
page('/logout', logoutPage);
page('/movies', moviesPage);
page('/my-movies', moviesPage);
page('/movies/?search/:movieSearchTitle', moviesPage);
page('/movies/:movieId', movieDetailsPage);
page('/add-movie', addMoviePage);
page('/edit/:movieId', editMoviePage);

page.start();