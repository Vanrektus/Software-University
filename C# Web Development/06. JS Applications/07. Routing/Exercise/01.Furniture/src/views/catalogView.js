import { render } from '../lib.js';
import { rootElement } from '../app.js';
import { getService } from '../services/furnitureServices.js';
import { updateNavBar } from '../api/api.js';
import catalogViewTemplate from '../templates/catalogViewTemplate.js';

export function catalogPage() {
    getService()
        .then(result => {
            let productViewTemplateResult = catalogViewTemplate(result);

            render(productViewTemplateResult, rootElement);
            updateNavBar();
        });
}