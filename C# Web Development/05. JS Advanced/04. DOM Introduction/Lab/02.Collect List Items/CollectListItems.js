function extractText() {
    let listItems = document.querySelectorAll("#items li");
    let result = "";

    for (const currListItem of listItems) {
        result += `${currListItem.textContent.trim()} \n`;
    }

    let resultElement = document.querySelector("#result");
    resultElement.textContent = result.trim();
}
