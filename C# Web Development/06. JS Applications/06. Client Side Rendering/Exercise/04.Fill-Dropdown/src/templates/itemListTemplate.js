import { html } from "../../../node_modules/lit-html/lit-html.js";
import itemTemplate from "./itemTemplate.js";

export default (items) => html `
    ${items.map(x => html`${itemTemplate(x)}`)}
`;