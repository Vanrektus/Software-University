import { html } from "../../node_modules/lit-html/lit-html.js";

export default (product) => html `
    <article>
        <header>
            <h1>${product.title}</h1>
        </header>

        <main>
            <p>Description: ${product.description}</p>
        </main>

        <footer>
            <p>Price: ${product.price}</p>
        </footer>
    </article>
`;