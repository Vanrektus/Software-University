// WITH EVENT DELEGATION
function encodeAndDecodeMessages() {

    let mainElement = document.querySelector('#main');

    mainElement.addEventListener('click', (e) => {
        if (e.target && e.target.textContent === 'Encode and send it') {

            let inputAreaElement = document.querySelector('textarea[placeholder="Write your message here..."]');
            let result = '';

            for (let i = 0; i < inputAreaElement.value.length; i++) {

                let nextASCIIchar = inputAreaElement.value.charCodeAt(i) + 1;
                result += String.fromCharCode(nextASCIIchar);
            }

            let outputAreaElement = document.querySelector('textarea[placeholder="No messages..."]');
            outputAreaElement.value = result;

            inputAreaElement.value = '';
        }

        if (e.target && e.target.textContent === 'Decode and read it') {

            let outputAreaElement = document.querySelector('textarea[placeholder="No messages..."]');
            let result = '';

            for (let i = 0; i < outputAreaElement.value.length; i++) {

                let nextASCIIchar = outputAreaElement.value.charCodeAt(i) - 1;
                result += String.fromCharCode(nextASCIIchar);
            }

            outputAreaElement.value = result;
        }
    });
}

function encodeAndDecodeMessages() {

    let encodeButtonElement = document.querySelectorAll('button')[0];
    let decodeButtonElement = document.querySelectorAll('button')[1];

    encodeButtonElement.addEventListener('click', (e) => {
        let inputAreaElement = document.querySelector('textarea[placeholder="Write your message here..."]');
        let result = '';

        for (let i = 0; i < inputAreaElement.value.length; i++) {

            let currASCIIchar = inputAreaElement.value.charCodeAt(i) + 1;
            result += String.fromCharCode(currASCIIchar);
        }

        let outputAreaElement = document.querySelector('textarea[placeholder="No messages..."]');
        outputAreaElement.value = result;

        inputAreaElement.value = '';
    });

    decodeButtonElement.addEventListener('click', (e) => {
        let outputAreaElement = document.querySelector('textarea[placeholder="No messages..."]');
        let result = '';

        for (let i = 0; i < outputAreaElement.value.length; i++) {

            let currASCIIchar = outputAreaElement.value.charCodeAt(i) - 1;
            result += String.fromCharCode(currASCIIchar);
        }

        outputAreaElement.value = result;
    });
}