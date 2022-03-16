import { rootElement } from '../app.js';
import { render } from '../lib.js';
import loginViewTemplate from '../templates/loginViewTemplate.js';

export function loginPage(context) {
    let loginViewTemplateResult = loginViewTemplate();

    let test = localStorage.getItem('userData');
    console.log(test);

    render(loginViewTemplateResult, rootElement);
}