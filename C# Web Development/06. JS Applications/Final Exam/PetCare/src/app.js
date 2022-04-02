import { page } from './lib.js';

import { authMiddleware } from './middlewares/authMiddleware.js';
import { navigationMiddleware } from './middlewares/navigationMiddleware.js';
import { renderMiddleware } from './middlewares/renderMiddleware.js';

import { homePage } from './views/homeView.js';
import { registerPage } from './views/registerView.js';
import { loginPage } from './views/loginView.js';
import { logoutPage } from './views/logoutView.js';
import { dashboardPage } from './views/dashboardView.js';
import { petDetailsPage } from './views/petDetailsView.js';
import { createPetPage } from './views/createPetView.js';
import { editPetPage } from './views/editPetView.js';

page(authMiddleware);
page(navigationMiddleware);
page(renderMiddleware);

page('/', homePage);
page('/register', registerPage);
page('/login', loginPage);
page('/logout', logoutPage);
page('/dashboard', dashboardPage);
page('/details/:petId', petDetailsPage);
page('/create', createPetPage);
page('/edit/:petId', editPetPage);

page.start();