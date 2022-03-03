function attachEvents() {
    let url = `http://localhost:3030/jsonstore/messenger`;

    let sendButtonElement = document.querySelector('#submit');
    sendButtonElement.addEventListener('click', sendMessageFunctionality);

    let refreshButtonElement = document.querySelector('#refresh');
    refreshButtonElement.addEventListener('click', refreshFunctionality);

    function sendMessageFunctionality() {
        let nameInputElement = document.querySelector('input[name=author]');
        let messageInputElement = document.querySelector('input[name=content]');

        fetch(url, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    author: nameInputElement.value,
                    content: messageInputElement.value
                })
            })
            .then(res => res.json())
            .then(data => {
                console.log(data);
            })
            .catch(err => {
                console.log(err);
            });

        nameInputElement.value = '';
        messageInputElement.value = '';
    }

    function refreshFunctionality(e) {
        e.preventDefault();

        let messagesAreaElement = document.querySelector('#messages');
        messagesAreaElement.textContent = '';

        fetch(url)
            .then(res => res.json())
            .then(messages => {
                Object.keys(messages)
                    .forEach(curr => messagesAreaElement.textContent += `${messages[curr].author}: ${messages[curr].content}\n`);
            })
            .catch(err => {
                console.log(err);
            });
    }
}

attachEvents();