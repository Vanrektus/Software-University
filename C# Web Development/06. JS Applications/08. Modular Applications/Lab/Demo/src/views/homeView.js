import { html } from '../lib.js';

let homeTemplate = () => html `
    <section>
        <h2>Home Page</h2>

        <p>Lorem ipsum dolor sit, amet consectetur adipisicing elit. Itaque, veritatis!</p>
    </section>
`;

export function homePage(context) {
    context.render(homeTemplate());
}