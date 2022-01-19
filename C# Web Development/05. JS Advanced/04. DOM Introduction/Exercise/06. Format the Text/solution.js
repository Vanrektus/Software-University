function solve() {
    let inputTextElement = document.querySelector("#input").value.split(".");

    while (inputTextElement[0]) {
        let text = document.createTextNode("");

        for (let i = 0; i < 3; i++) {
            if (inputTextElement[0]) {
                text.appendData(inputTextElement[0] + ".");
                inputTextElement.shift();
            }
        }

        let child = document.createElement("p");
        child.appendChild(text);

        let outputToAddElement = document.querySelector("#output");
        outputToAddElement = outputToAddElement.appendChild(child);
    }
}
