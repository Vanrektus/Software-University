function generateReport() {

    let headerArrayElement = Array.from(document.querySelectorAll('input'));
    const objArray = [];
    let bodyArrayElement = Array.from(document.querySelectorAll('tr'));
    const checkedCols = [];

    for (let i = 0; i < bodyArrayElement.length; i++) {

        const currentRow = bodyArrayElement[i];
        const obj = {};

        for (let j = 0; j < currentRow.children.length; j++) {

            const element = currentRow.children[j];

            if (i == 0) {

                if (element.children[0].checked) {

                    checkedCols.push(j);
                }

                continue;
            }

            if (checkedCols.includes(j)) {

                let propertyName = headerArrayElement[j].name;
                obj[propertyName] = element.textContent;
            }
        }

        if (i !== 0) {

            objArray.push(obj);
        }
    }

    let outputElement = document.querySelector('#output');
    outputElement.value = JSON.stringify(objArray);
}