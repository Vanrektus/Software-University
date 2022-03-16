import { getProducts, updateNavBar } from '../api/api.js';
import { rootElement } from '../app.js';
import { render } from '../lib.js';
import catalogViewTemplate from '../templates/catalogViewTemplate.js';

export function catalogPage(context) {
    getProducts()
        .then(result => {
            let productViewTemplateResult = catalogViewTemplate(result);

            render(productViewTemplateResult, rootElement);
            updateNavBar();
        });
}