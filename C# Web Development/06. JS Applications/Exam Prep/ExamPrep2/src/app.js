import { page } from './lib.js';

import { authMiddleware } from './middlewares/authMiddleware.js';
import { navigationMiddleware } from './middlewares/navigationMiddleware.js';
import { renderMiddleware } from './middlewares/renderMiddleware.js';

import { homePage } from './views/homeView.js';
import { registerPage } from './views/registerView.js';
import { loginPage } from './views/loginView.js';
import { logoutPage } from './views/logoutView.js';
import { listingsPage } from './views/listingsView.js';
import { carDetailsPage } from './views/carDetailsView.js';
import { addCarPage } from './views/addCarView.js';
import { editCarPage } from './views/editCarView.js';
import { myListingsPage } from './views/myListingsView.js';
import { searchPage } from './views/searchView.js';

page(authMiddleware);
page(navigationMiddleware);
page(renderMiddleware);

page('/', homePage);
page('/register', registerPage);
page('/login', loginPage);
page('/logout', logoutPage);
page('/listings', listingsPage);
page('/listings/:carId', carDetailsPage);
page('/create', addCarPage);
page('/edit/:carId', editCarPage);
page('/my-listings', myListingsPage);
page('/search', searchPage);

page.start();