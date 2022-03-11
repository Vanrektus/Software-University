import { html } from "../../../node_modules/lit-html/lit-html.js";
import studentTemplate from "./studentTemplate.js";

export default (students) => html `
    ${students.map(x => html`${studentTemplate(x)}`)}
`;