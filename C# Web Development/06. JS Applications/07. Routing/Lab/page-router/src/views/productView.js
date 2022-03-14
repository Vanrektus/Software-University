import { render } from "../../node_modules/lit-html/lit-html.js";
import productsData from "../productsData.js";
import detailedProductTemplate from "../templates/detailedProductTemplate.js";
import { titleFormatter } from '../utils/utils.js'

export default function(context) {
    let rootElement = document.querySelector('.root');

    let currentProduct = productsData.find(x => titleFormatter(x.title) == context.params.id);

    let currProductResult = detailedProductTemplate(currentProduct);

    render(currProductResult, rootElement);
}