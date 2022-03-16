import { rootElement } from '../app.js';
import { render } from '../lib.js';
import createViewTemplate from '../templates/createViewTemplate.js';

export function createPage() {
    let createViewTemplateResult = createViewTemplate();

    render(createViewTemplateResult, rootElement);
}