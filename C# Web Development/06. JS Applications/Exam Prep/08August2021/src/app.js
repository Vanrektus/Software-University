import { page } from './lib.js';

import { authMiddleware } from './middlewares/authMiddleware.js';
import { navigationMiddleware } from './middlewares/navigationMiddleware.js';
import { renderMiddleware } from './middlewares/renderMiddleware.js';

import { homePage } from './views/homeView.js';
import { registerPage } from './views/registerView.js';
import { loginPage } from './views/loginView.js';
import { logoutPage } from './views/logoutView.js';
import { bookDetailsPage } from './views/bookDetailsView.js';
import { createBookPage } from './views/createBookView.js';
import { editBookPage } from './views/editBookView.js';
import { myBooksPage } from './views/myBooksView.js';

page(authMiddleware);
page(navigationMiddleware);
page(renderMiddleware);

page('/', homePage);
page('/register', registerPage);
page('/login', loginPage);
page('/logout', logoutPage);
page('/details/:bookId', bookDetailsPage);
page('/create', createBookPage);
page('/edit/:bookId', editBookPage);
page('/my-books', myBooksPage);

page.start();