import { render } from "../node_modules/lit-html/lit-html.js";
import { cats } from "./src/services/catSeeder.js";
import catListTemplate from "./src/templates/catListTemplate.js";

let rootElement = document.querySelector('#allCats');

let catListTemplateResult = catListTemplate(cats);

render(catListTemplateResult, rootElement);