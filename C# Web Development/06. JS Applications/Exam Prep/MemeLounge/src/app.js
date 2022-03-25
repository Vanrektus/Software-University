import { page } from './lib.js';

import { authMiddleware } from './middlewares/authMiddleware.js';
import { navigationMiddleware } from './middlewares/navigationMiddleware.js';
import { renderMiddleware } from './middlewares/renderMiddleware.js';

import { homePage } from './views/homeView.js';
import { registerPage } from './views/registerView.js';
import { loginPage } from './views/loginView.js';
import { logoutPage } from './views/logoutView.js';
import { allMemesPage } from './views/allMemesView.js';
import { memeDetailsPage } from './views/memeDetailsView.js';
import { createMemePage } from './views/createMemeView.js';
import { editMemePage } from './views/editMemeView.js';
import { userProfilePage } from './views/userProfileView.js';

page(authMiddleware);
page(navigationMiddleware);
page(renderMiddleware);

page('/', homePage);
page('/register', registerPage);
page('/login', loginPage);
page('/logout', logoutPage);
page('/all-memes', allMemesPage);
page('/details/:memeId', memeDetailsPage);
page('/create', createMemePage);
page('/edit/:memeId', editMemePage);
page('/my-profile', userProfilePage);

page.start();