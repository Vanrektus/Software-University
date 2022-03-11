const url = "http://localhost:3030/jsonstore/advanced/dropdown";
let inputElement = document.querySelector('#itemText');

export function sendItem() {
    if (inputElement.value.length < 1) {
        return;
    }

    fetch(url, {
        method: 'POST',
        headers: {
            'content-type': 'application/json'
        },
        body: JSON.stringify({
            text: inputElement.value
        })
    });
}