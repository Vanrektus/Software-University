import { render } from "../../../node_modules/lit-html/lit-html.js";
import { getStudents } from "./getStudentsService.js";
import studentListTemplate from "../templates/studentListTemplate.js";

export function renderStudents() {
    let rootElement = document.querySelector('tbody');

    getStudents()
        .then(result => {
            let students = Object.values(result);

            let studentListTemplateResult = studentListTemplate(students);

            render(studentListTemplateResult, rootElement);
        })
}