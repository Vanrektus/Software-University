import { updateNavBar } from './api/api.js';
import { page } from './lib.js';
import { catalogPage } from './views/catalogView.js';
import { createPage } from './views/createView.js';
import { detailsPage } from './views/detailsView.js';
import { editPage } from './views/editView.js';
import { loginPage } from './views/loginView.js';
import { myFurniturePage } from './views/myFurnitureView.js';
import { registerPage } from './views/registerView.js';

export let rootElement = document.querySelector('.root');

page('/', catalogPage);
page('/login', loginPage);
page('/register', registerPage);
page('/create', createPage);
page('/edit/:id', editPage);
page('/details/:id', detailsPage);
page('/my-furniture', myFurniturePage);

page.start();