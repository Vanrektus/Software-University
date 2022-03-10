import { html } from "../../../node_modules/lit-html/lit-html.js";
import townTemplate from "./townTemplate.js";

export default (towns) => html `
    <ul>
        ${towns.map(x => html`${townTemplate(x)}`)}
    </ul>
`;