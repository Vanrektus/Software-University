import { render } from '../lib.js';
import { rootElement } from '../app.js';
import { getService } from '../services/furnitureServices.js';
import { updateDetailsButtons } from '../api/api.js';
import detailsViewTemplate from '../templates/detailsViewTemplate.js';

export function detailsPage(context) {
    getService()
        .then(result => {
            let desiredFurniture = result.filter(x => x._id === context.params.id)[0];

            let detailsViewTemplateResult = detailsViewTemplate(desiredFurniture);

            render(detailsViewTemplateResult, rootElement);

            updateDetailsButtons(desiredFurniture);
        });
}