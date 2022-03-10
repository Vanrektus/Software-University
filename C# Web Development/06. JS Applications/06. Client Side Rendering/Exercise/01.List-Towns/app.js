import { render } from "../node_modules/lit-html/lit-html.js";
import townListTemplate from "./src/templates/townListTemplate.js";

document.addEventListener('click', (e) => {
    e.preventDefault();

    if (e.target && e.target.nodeName !== 'BUTTON') {
        return;
    }

    let rootElement = document.querySelector('#root');

    let townsInputElement = document.querySelector('#towns');
    let splitInput = townsInputElement.value.split(', ');

    if (splitInput[0] === "") {
        return;
    }

    let townListTemplateResult = townListTemplate(splitInput);

    render(townListTemplateResult, rootElement);

    townsInputElement.value = '';
});