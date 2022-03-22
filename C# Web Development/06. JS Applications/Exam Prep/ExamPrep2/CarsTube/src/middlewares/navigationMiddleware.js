import { render } from '../lib.js';
import { renderNavigation } from '../views/navigationView.js';

const rootElement = document.querySelector('.navigtation');

export function navigationMiddleware(context, next) {
    render(renderNavigation(context), rootElement);

    next();
}