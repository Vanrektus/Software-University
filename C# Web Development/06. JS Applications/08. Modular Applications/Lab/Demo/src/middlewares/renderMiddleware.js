import { render } from '../lib.js';
import { renderNavigation } from '../views/navigationView.js';

const rootElement = document.querySelector('.root');
const navigationElement = document.querySelector('.navigation');

// const contextRender = templateResult => {
//     render(renderNavigation(), navigationElement);
//     render(templateResult, rootElement);
// }
function contextRender(templateResult) {
    render(templateResult, rootElement);
}

export function renderMiddleware(context, next) {
    render(renderNavigation(context), navigationElement);

    context.render = contextRender;

    next();
}