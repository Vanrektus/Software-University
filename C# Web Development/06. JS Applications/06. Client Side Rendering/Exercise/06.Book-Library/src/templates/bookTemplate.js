import { html } from "../../../node_modules/lit-html/lit-html.js";
import { editFunctionality, deleteFunctionality } from "../services/onClickHandlerService.js";

export default (books, x) => html `
    <tr id="${x}">
        <td>${books[x].title}</td>
        <td>${books[x].author}</td>
        <td>
            <button @click=${editFunctionality}>Edit</button>
            <button @click=${deleteFunctionality}>Delete</button>
        </td>
    </tr>
`;