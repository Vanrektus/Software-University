function solve() {
    let textElement = document.querySelector("#text").value.split(" ");
    let namingConventionElement =
        document.querySelector("#naming-convention").value;
    let resultText = "";

    if (namingConventionElement == "Camel Case") {
        let index = 0;

        for (const currWord of textElement) {
            let newWord = currWord.toLowerCase();

            if (index != 0) {
                newWord = newWord.charAt(0).toUpperCase() + newWord.slice(1);
            }

            resultText += newWord;
            index++;
        }
    } else if (namingConventionElement == "Pascal Case") {
        for (const currWord of textElement) {
            let newWord = currWord.toLowerCase();
            newWord = newWord.charAt(0).toUpperCase() + newWord.slice(1);

            resultText += newWord;
        }
    } else {
        resultText = "Error!";
    }

    let resultElement = document.querySelector("#result");
    resultElement.textContent = resultText;
}
