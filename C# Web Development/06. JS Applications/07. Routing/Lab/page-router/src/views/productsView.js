import { render } from "../../node_modules/lit-html/lit-html.js";
import productsData from "../productsData.js";
import productListTemplate from "../templates/productListTemplate.js";

export default function(context) {
    let rootElement = document.querySelector('.root');

    let productsListResult = productListTemplate(productsData);

    render(productsListResult, rootElement);
}