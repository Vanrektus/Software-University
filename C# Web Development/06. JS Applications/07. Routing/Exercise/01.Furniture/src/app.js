import { page } from './lib.js';
import { catalogPage } from './views/catalogView.js';
import { loginPage } from './views/loginView.js';
import { registerPage } from './views/registerView.js';
import { createPage } from './views/createView.js';
import { myFurniturePage } from './views/myFurnitureView.js';
import { detailsPage } from './views/detailsView.js';
import { editPage } from './views/editView.js';

export const rootElement = document.querySelector('.root');

page('/', catalogPage);
page('/login', loginPage);
page('/register', registerPage);
page('/create', createPage);
page('/my-furniture', myFurniturePage);
page('/details/:id', detailsPage);
page('/edit/:id', editPage);

page.start();