import { render } from '../lib.js';
import { rootElement } from '../app.js';
import { getService } from '../services/furnitureServices.js';
import { updateNavBar } from '../api/api.js';
import myFurnitureViewTemplate from '../templates/myFurnitureViewTemplate.js';

export function myFurniturePage() {
    getService()
        .then(result => {
            let userData = JSON.parse(localStorage.getItem('userData'));
            let sortedResult = result.filter(x => x._ownerId === userData.id);

            let productViewTemplateResult = myFurnitureViewTemplate(sortedResult);

            render(productViewTemplateResult, rootElement);
            updateNavBar();
        });
}