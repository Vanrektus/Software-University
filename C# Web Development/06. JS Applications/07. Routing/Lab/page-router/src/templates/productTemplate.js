import { html } from "../../node_modules/lit-html/lit-html.js";
import { titleFormatter } from '../utils/utils.js';

export default (product) => html `
    <article>
        <h3>${product.title}</h3>
        <a href="/products/${titleFormatter(product.title)}">Read More</a>
    </article>
`;