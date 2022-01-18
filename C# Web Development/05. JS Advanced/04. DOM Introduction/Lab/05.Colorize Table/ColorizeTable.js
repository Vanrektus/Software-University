function colorize() {
    let evenRows = document.querySelectorAll("tr:nth-of-type(2n)");

    for (const currEl of evenRows) {
        currEl.style.backgroundColor = "teal";
    }
}
