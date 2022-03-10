import { html } from "../../node_modules/lit-html/lit-html.js";
import contactTemplate from "./contactTemplate.js";
import onClickHandler from "./onClickHandler.js";

export default (contacts) => html `${contacts.map(x => html`${contactTemplate(x, onClickHandler)}`)}`;