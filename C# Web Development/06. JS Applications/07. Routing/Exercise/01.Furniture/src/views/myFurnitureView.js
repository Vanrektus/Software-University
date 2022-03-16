import { getProducts, updateNavBar } from '../api/api.js';
import { rootElement } from '../app.js';
import { render } from '../lib.js';
import catalogViewTemplate from '../templates/catalogViewTemplate.js';

export function myFurniturePage(context) {
    getProducts()
        .then(result => {
            let userData = JSON.parse(localStorage.getItem('userData'));
            console.log(userData.id);
            let sortedResult = result.filter(x => x._ownerId === userData.id);

            let productViewTemplateResult = catalogViewTemplate(sortedResult);

            render(productViewTemplateResult, rootElement);
            updateNavBar();
        });
}