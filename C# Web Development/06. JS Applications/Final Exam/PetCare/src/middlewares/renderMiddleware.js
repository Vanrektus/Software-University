import { render } from '../lib.js';

const rootElement = document.querySelector('.main-content');

function contextRender(templateResult) {
    render(templateResult, rootElement);
}

export function renderMiddleware(context, next) {
    context.render = contextRender;

    next();
}