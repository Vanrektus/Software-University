import { render } from '../lib.js';
import { rootElement } from '../app.js';
import loginViewTemplate from '../templates/loginViewTemplate.js';

export function loginPage(context) {
    let loginViewTemplateResult = loginViewTemplate();

    render(loginViewTemplateResult, rootElement);
}