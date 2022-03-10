import { render } from "./node_modules/lit-html/lit-html.js";
import { contacts } from "./src/services/contacts.js";
import contactListTemplate from "./src/templates/contactListTemplate.js";

let rootElement = document.querySelector('#contacts');

let contactListTemplateResult = contactListTemplate(contacts);

render(contactListTemplateResult, rootElement);