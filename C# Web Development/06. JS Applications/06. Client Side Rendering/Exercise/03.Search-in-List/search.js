import { render } from "../node_modules/lit-html/lit-html.js";
import { towns } from "./src/services/towns.js";
import townListTemplate from "./src/templates/townListTemplate.js";
import onClickHandler from "./src/templates/onClickHandler.js";

let rootElement = document.querySelector('#towns');

let townListTemplateResult = townListTemplate(towns);

render(townListTemplateResult, rootElement);

document.addEventListener('click', onClickHandler);