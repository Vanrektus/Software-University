import { render } from "../../../node_modules/lit-html/lit-html.js";
import { getItems } from "./getItemsService.js";
import itemListTemplate from "../templates/itemListTemplate.js";

export function renderItems() {
    let rootElement = document.querySelector('#menu');

    getItems()
        .then(result => {
            let options = Object.values(result);

            let itemListTemplateResult = itemListTemplate(options);

            render(itemListTemplateResult, rootElement);
        });
}