import searchFunctionality from "./src/services/onClickHandlerService.js";
import { renderStudents } from "./src/services/renderStudentsService.js";

document.addEventListener('click', searchFunctionality);

renderStudents();