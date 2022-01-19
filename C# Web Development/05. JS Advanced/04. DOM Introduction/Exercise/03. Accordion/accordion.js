function toggle() {
    let buttonElement = document.querySelector(".button");
    let textToShowElement = document.querySelector("#extra");

    switch (buttonElement.textContent) {
        case "More":
            textToShowElement.style.display = "block";

            buttonElement.textContent = "Less";
            break;

        case "Less":
            textToShowElement.style.display = "none";

            buttonElement.textContent = "More";
            break;
    }
}
