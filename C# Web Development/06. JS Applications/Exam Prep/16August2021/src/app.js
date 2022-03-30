import { page } from './lib.js';

import { authMiddleware } from './middlewares/authMiddleware.js';
import { navigationMiddleware } from './middlewares/navigationMiddleware.js';
import { renderMiddleware } from './middlewares/renderMiddleware.js';

import { homePage } from './views/homeView.js';
import { registerPage } from './views/registerView.js';
import { loginPage } from './views/loginView.js';
import { logoutPage } from './views/logoutView.js';
import { allGamesPage } from './views/allGamesView.js';
import { gameDetailsPage } from './views/gameDetailsView.js';
import { createGamePage } from './views/createGameView.js';
import { editGamePage } from './views/editGameView.js';

page(authMiddleware);
page(navigationMiddleware);
page(renderMiddleware);

page('/', homePage);
page('/register', registerPage);
page('/login', loginPage);
page('/logout', logoutPage);
page('/all-games', allGamesPage);
page('/details/:gameId', gameDetailsPage);
page('/create', createGamePage);
page('/edit/:gameId', editGamePage);

page.start();