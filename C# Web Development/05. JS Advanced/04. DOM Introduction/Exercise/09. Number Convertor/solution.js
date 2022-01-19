function solve() {

    let binaryOption = document.createElement('option');
    binaryOption.value = 'binary';
    binaryOption.innerHTML = 'Binary';

    let hexadecimalOption = document.createElement('option');
    hexadecimalOption.value = 'hexadecimal';
    hexadecimalOption.innerHTML = 'Hexadecimal';

    document.getElementById('selectMenuTo').appendChild(binaryOption);
    document.getElementById('selectMenuTo').appendChild(hexadecimalOption);

    const convert = function convert() {

        let numberToConvert = document.querySelector('#input').value;
        let selectOption = document.querySelector('#selectMenuTo').value;
        let result = '';

        switch (selectOption) {
            case 'binary':

                result = Number(numberToConvert).toString(2);
                break;

            case 'hexadecimal':

                result = Number(numberToConvert).toString(16).toUpperCase();
                break;
        }

        document.querySelector('#result').value = result;
    }

    const button = document.querySelector('button');
    button.onclick = convert;
}