function search() {
    let townsElementsArray = Array.from(document.querySelectorAll("#towns li"));
    let searchBoxElement = document.querySelector("#searchText").value;
    let numberOfMatchesFound = 0;

    for (const currTown of townsElementsArray) {
        if (currTown.textContent.includes(searchBoxElement)) {
            numberOfMatchesFound++;

            currTown.style.textDecoration = "underline";
            currTown.style.fontWeight = "bold";
        }
    }

    let resultElement = document.querySelector("#result");
    resultElement.textContent = `${numberOfMatchesFound} matches found`;
}
