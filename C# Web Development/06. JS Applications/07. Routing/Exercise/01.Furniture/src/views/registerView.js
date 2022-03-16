import { rootElement } from '../app.js';
import { render } from '../lib.js';
import registerViewTemplate from '../templates/registerViewTemplate.js';

export function registerPage() {
    let registerViewTemplateResult = registerViewTemplate();

    render(registerViewTemplateResult, rootElement);
}