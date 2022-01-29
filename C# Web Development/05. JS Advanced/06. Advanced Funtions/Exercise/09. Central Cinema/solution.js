function solve() {
    // Input elements
    let inputElements = document.querySelectorAll('#container input');
    let inputNameElement = inputElements[0];
    let inputHallElement = inputElements[1];
    let inputPriceElement = inputElements[2];

    // Movies and archive sections
    let moviesSectionElement = document.querySelector('#movies ul');
    let archiveSectionElement = document.querySelector('#archive ul');

    // Buttons elements
    let buttonsElements = document.querySelectorAll('button');

    // Add movie button
    let onScreenButtonElement = buttonsElements[0];
    onScreenButtonElement.addEventListener('click', addMovie)

    // Clear archive button
    let clearButtonElement = buttonsElements[1];
    clearButtonElement.addEventListener('click', clearArchive)

    function addMovie(e) {
        e.preventDefault();

        if (inputNameElement.value && inputHallElement.value && inputPriceElement.value && !isNaN(Number(inputPriceElement.value))) {
            // Creating elements
            let liElement = document.createElement('li');

            let spanNameElement = document.createElement('span');
            spanNameElement.textContent = inputNameElement.value;

            let strongHallElement = document.createElement('strong');
            strongHallElement.textContent = `Hall: ${inputHallElement.value}`;

            let divElement = document.createElement('div');

            let strongPriceElement = document.createElement('strong');
            strongPriceElement.textContent = Number(inputPriceElement.value).toFixed(2);

            let inputPlaceholderElement = document.createElement('input');
            inputPlaceholderElement.setAttribute('placeholder', "Tickets Sold");

            let archiveButtonElement = document.createElement('button');
            archiveButtonElement.textContent = 'Archive';
            archiveButtonElement.addEventListener('click', archiveMovie);

            // Appending elements
            divElement.appendChild(strongPriceElement);
            divElement.appendChild(inputPlaceholderElement);
            divElement.appendChild(archiveButtonElement);

            liElement.appendChild(spanNameElement);
            liElement.appendChild(strongHallElement);
            liElement.appendChild(divElement);

            moviesSectionElement.appendChild(liElement);

        }

        inputNameElement.value = '';
        inputHallElement.value = '';
        inputPriceElement.value = '';

        function archiveMovie(e) {
            if (e.target.previousSibling.value && !isNaN(Number(e.target.previousSibling.value))) {
                // Creating elements
                let liElement = document.createElement('li');

                let spanNameElement = document.createElement('span');
                spanNameElement.textContent = e.target.parentElement.previousSibling.previousSibling.textContent;

                let strongPriceElement = document.createElement('strong');
                strongPriceElement.textContent = `Total amount: ${(Number(e.target.previousSibling.previousSibling.textContent) * Number(e.target.previousSibling.value)).toFixed(2)}`;

                let deleteButtonElement = document.createElement('button');
                deleteButtonElement.textContent = 'Delete';
                deleteButtonElement.addEventListener('click', (e) => e.target.parentElement.remove());

                // Appending elements
                liElement.appendChild(spanNameElement);
                liElement.appendChild(strongPriceElement);
                liElement.appendChild(deleteButtonElement);

                archiveSectionElement.appendChild(liElement);

                e.target.parentElement.parentElement.remove();
            }
        }
    }

    function clearArchive() {
        Array.from(archiveSectionElement.querySelectorAll('li')).forEach(x => x.remove());
    }
}