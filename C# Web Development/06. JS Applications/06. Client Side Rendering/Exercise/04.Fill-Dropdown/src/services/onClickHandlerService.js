import { sendItem } from "./sendItemsService.js";
import { renderItems } from "./renderItemsService.js";

let inputElement = document.querySelector('#itemText');

export default function submitFunctionality(e) {
    e.preventDefault();

    if (!(e.target &&
            e.target.nodeName === 'INPUT' &&
            e.target.value === 'Add' &&
            e.target.type === 'submit')) {
        return;
    }

    sendItem();

    inputElement.value = '';

    renderItems();
}