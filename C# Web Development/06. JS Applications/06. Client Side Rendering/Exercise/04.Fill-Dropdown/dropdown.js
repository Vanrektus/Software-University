import { render } from "../node_modules/lit-html/lit-html.js";
import submitFunctionality from "./src/services/onClickHandlerService.js";
import { getItems } from "./src/services/getItemsService.js";
import itemListTemplate from "./src/templates/itemListTemplate.js";
import { renderItems } from "./src/services/renderItemsService.js";

document.addEventListener('click', submitFunctionality);

renderItems();