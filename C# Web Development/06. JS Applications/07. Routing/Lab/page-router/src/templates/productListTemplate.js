import { html } from "../../node_modules/lit-html/lit-html.js";
import productTemplate from "./productTemplate.js";

export default (products) => html `
    ${products.map(x => html`${productTemplate(x)}`)}
`;