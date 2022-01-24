function solve() {
    let generateButtonElement = document.querySelectorAll('button')[0];
    let buyButtonElement = document.querySelectorAll('button')[1];

    generateButtonElement.addEventListener('click', (e) => {
        let inputElement = document.querySelector('textarea');
        let inputObj = JSON.parse(inputElement.value);

        for (let i = 0; i < inputObj.length; i++) {
            let furnitureImg = inputObj[i].img;
            let furnitureName = inputObj[i].name;
            let furniturePrice = inputObj[i].price;
            let furnitureDecFactor = inputObj[i].decFactor;

            // tr element
            let trElement = document.createElement('tr');

            // td element with image source (create and append)
            let tdImgElement = document.createElement('td');
            let imgElement = document.createElement('img');
            imgElement.src = furnitureImg;
            tdImgElement.appendChild(imgElement);

            // td element with name (create and append)
            let tdNameElement = document.createElement('td');
            let nameElement = document.createElement('p');
            nameElement.textContent = furnitureName;
            tdNameElement.appendChild(nameElement);

            // td element with price (create and append)
            let tdPriceElement = document.createElement('td');
            let priceElement = document.createElement('p');
            priceElement.textContent = furniturePrice;
            tdPriceElement.appendChild(priceElement);

            // td element with decoration factor (create and append)
            let tdDecFactorElement = document.createElement('td');
            let factorElement = document.createElement('p');
            factorElement.textContent = furnitureDecFactor;
            tdDecFactorElement.appendChild(factorElement);

            // td element with checkbox (create and append)
            let tdCheckboxElement = document.createElement('td');
            let checkboxElement = document.createElement('input');
            checkboxElement.type = 'checkbox';
            tdCheckboxElement.appendChild(checkboxElement);

            // append all td elements to tr element
            trElement.appendChild(tdImgElement);
            trElement.appendChild(tdNameElement);
            trElement.appendChild(tdPriceElement);
            trElement.appendChild(tdDecFactorElement);
            trElement.appendChild(tdCheckboxElement);

            // append tr element to tbody element
            document.querySelector('tbody').appendChild(trElement);
        }
    });

    buyButtonElement.addEventListener('click', (e) => {
        let furnitureCheckedElementsArray = Array.from(document.querySelectorAll('input[type="checkbox"]:checked'));
        let furnituresNames = [];
        let furnituresTotalPrice = 0;
        let averageDecFactor = 0;

        for (let i = 0; i < furnitureCheckedElementsArray.length; i++) {
            let currFurnitureName = furnitureCheckedElementsArray[i].parentNode.parentNode.querySelectorAll('td')[1];
            let currFurniturePrice = furnitureCheckedElementsArray[i].parentNode.parentNode.querySelectorAll('td')[2];
            let currDecFactor = furnitureCheckedElementsArray[i].parentNode.parentNode.querySelectorAll('td')[3];

            furnituresNames.push(currFurnitureName.textContent);
            furnituresTotalPrice += Number(currFurniturePrice.textContent);
            averageDecFactor += Number(currDecFactor.textContent);
        }

        averageDecFactor /= furnitureCheckedElementsArray.length;

        let outputAreaElement = document.querySelectorAll('textarea')[1];

        outputAreaElement.textContent = `Bought furniture: ${furnituresNames.join(', ')}\n`;
        outputAreaElement.textContent += `Total price: ${furnituresTotalPrice.toFixed(2)}\n`;
        outputAreaElement.textContent += `Average decoration factor: ${averageDecFactor}`;
    });
}