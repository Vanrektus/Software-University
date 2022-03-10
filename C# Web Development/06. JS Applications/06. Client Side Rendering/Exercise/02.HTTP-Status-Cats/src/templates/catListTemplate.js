import { html } from "../../../node_modules/lit-html/lit-html.js";
import catTemplate from "./catTemplate.js";
import onClickHandler from "./onClickHandler.js";

export default (cats) => html `
    <ul>
        ${cats.map(x => html`${catTemplate(x, onClickHandler)}`)}
    </ul>
`;