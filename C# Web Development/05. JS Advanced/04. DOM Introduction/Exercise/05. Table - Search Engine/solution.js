function solve() {
    document.querySelector("#searchBtn").addEventListener("click", onClick);

    function onClick() {
        let searchBoxElement = document.querySelector("#searchField").value.toLowerCase();

        let tableElementsArray = Array.from(document.querySelectorAll("tbody tr"));

        for (const currElement of tableElementsArray) {

            currElement.classList.remove("select");
        }

        for (const currElement of tableElementsArray.filter((x) => x.textContent.toLowerCase().includes(searchBoxElement))) {

            currElement.classList.add("select");
        }

        document.querySelector("#searchField").value = "";
    }
}