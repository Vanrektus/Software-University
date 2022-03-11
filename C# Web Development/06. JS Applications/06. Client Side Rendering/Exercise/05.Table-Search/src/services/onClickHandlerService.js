export default function searchFunctionality(e) {
    e.preventDefault();

    if (!(e.target &&
            e.target.nodeName === 'BUTTON' &&
            e.target.id === 'searchBtn')) {
        return;
    }

    let searchBoxElement = document.querySelector("#searchField").value.toLowerCase();
    let tableElementsArray = Array.from(document.querySelectorAll("tbody tr"));

    if (searchBoxElement === "") {
        tableElementsArray
            .map(x => x.classList.remove("select"));

        return;
    }

    tableElementsArray
        .map(x => x.classList.remove("select"));

    tableElementsArray
        .filter((x) => x.textContent.toLowerCase().includes(searchBoxElement))
        .map(x => x.classList.add("select"));

    document.querySelector("#searchField").value = "";
}