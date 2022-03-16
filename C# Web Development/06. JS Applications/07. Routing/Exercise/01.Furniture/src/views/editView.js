import { render } from '../lib.js';
import { rootElement } from '../app.js';
import { getService } from '../services/furnitureServices.js';
import editViewTemplate from '../templates/editViewTemplate.js';

export function editPage(context) {

    getService()
        .then(result => {
            let currentFurniture = result.filter(x => x._id === context.params.id)[0];

            let editViewTemplateResult = editViewTemplate(currentFurniture);

            render(editViewTemplateResult, rootElement);
        });
}