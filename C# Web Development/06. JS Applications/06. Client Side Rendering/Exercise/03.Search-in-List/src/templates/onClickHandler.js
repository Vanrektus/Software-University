export default function handleClick(e) {
    e.preventDefault();

    if (e.target && e.target.nodeName !== 'BUTTON') {
        return;
    }

    let townsElementsArray = Array.from(document.querySelectorAll("#towns li"));
    let searchBoxElement = document.querySelector("#searchText").value;
    let resultElement = document.querySelector("#result");
    let numberOfMatchesFound = 0;

    townsElementsArray.map(x => {
        x.style.textDecoration = "none";
        x.style.fontWeight = "normal";
    });

    if (searchBoxElement === "") {
        resultElement.textContent = `${numberOfMatchesFound} matches found`;
        return;
    }

    for (const currTown of townsElementsArray) {
        if (currTown.textContent.includes(searchBoxElement)) {
            numberOfMatchesFound++;

            currTown.style.textDecoration = "underline";
            currTown.style.fontWeight = "bold";
        }
    }

    resultElement.textContent = `${numberOfMatchesFound} matches found`;
}