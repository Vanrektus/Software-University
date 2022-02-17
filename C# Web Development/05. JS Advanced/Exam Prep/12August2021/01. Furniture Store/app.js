window.addEventListener('load', solve);

function solve() {
    let addButtonElement = document.querySelector('#add');

    addButtonElement.addEventListener('click', (e) => {
        e.preventDefault();

        let modelInputElement = document.querySelector('#model');
        let yearInputElement = document.querySelector('#year');
        let descriptionInputElement = document.querySelector('#description');
        let priceInputElement = document.querySelector('#price');

        if (inputCheck(modelInputElement.value,
                yearInputElement.value,
                descriptionInputElement.value,
                priceInputElement.value)) {
            createElements(modelInputElement, yearInputElement, descriptionInputElement, priceInputElement);
        }
    })

    function createElements(model, year, description, price) {
        // Create elements

        // Info Section
        let trInfoElement = document.createElement('tr');
        trInfoElement.setAttribute('class', 'info');

        let tdModelElement = document.createElement('td');
        tdModelElement.textContent = model.value;
        let tdPriceElement = document.createElement('td');
        tdPriceElement.textContent = Number(price.value).toFixed(2);
        let tdButtonsElement = document.createElement('td');

        let moreInfoButtonElement = document.createElement('button');
        moreInfoButtonElement.setAttribute('class', 'moreBtn');
        moreInfoButtonElement.textContent = 'More Info';
        moreInfoButtonElement.addEventListener('click', moreInfoFunction);

        let buyButtonElement = document.createElement('button');
        buyButtonElement.setAttribute('class', 'buyBtn');
        buyButtonElement.textContent = 'Buy it';
        buyButtonElement.addEventListener('click', buyFunction);

        // Hidden section
        let trHideElement = document.createElement('tr');
        trHideElement.setAttribute('class', 'hide');
        trHideElement.setAttribute('style', 'display:none');

        let tdYearElement = document.createElement('td');
        tdYearElement.textContent = `Year: ${year.value}`;
        let tdDescriptionElement = document.createElement('td');
        tdDescriptionElement.setAttribute('colspan', 3);
        tdDescriptionElement.textContent = `Description: ${description.value}`;

        // Append elements
        tdButtonsElement.appendChild(moreInfoButtonElement);
        tdButtonsElement.appendChild(buyButtonElement);

        trInfoElement.appendChild(tdModelElement);
        trInfoElement.appendChild(tdPriceElement);
        trInfoElement.appendChild(tdButtonsElement);

        trHideElement.appendChild(tdYearElement);
        trHideElement.appendChild(tdDescriptionElement);

        let furnitureListElement = document.querySelector('#furniture-list');
        furnitureListElement.appendChild(trInfoElement);
        furnitureListElement.appendChild(trHideElement);
    }

    function moreInfoFunction(e) {
        e.preventDefault();

        let moreLessButtonElement = document.querySelector('.moreBtn');
        let hideElement = document.querySelector('.hide');

        if (moreLessButtonElement.textContent === 'More Info') {
            hideElement.setAttribute('style', 'display:contents;');
            moreLessButtonElement.textContent = 'Less Info';
        } else if (moreLessButtonElement.textContent === 'Less Info') {
            hideElement.setAttribute('style', 'display:none;');
            moreLessButtonElement.textContent = 'More Info';
        }

    }

    function buyFunction(e) {
        e.preventDefault();

        let totalPriceElement = document.querySelector('.total-price');
        let furniturePriceElement = e.target.parentNode.previousSibling;
        totalPriceElement.textContent = (Number(totalPriceElement.textContent) + Number(furniturePriceElement.textContent)).toFixed(2);

        e.target.parentNode.parentNode.nextSibling.remove();
        e.target.parentNode.parentNode.remove();

    }

    function inputCheck(model, year, description, price) {
        if (model && year && description && price &&
            Number(year) && Number(price) &&
            Number(year) > 0 && Number(price > 0)) {
            return true;
        }

        return false;
    }
}