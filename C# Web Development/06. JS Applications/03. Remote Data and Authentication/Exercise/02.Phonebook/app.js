function attachEvents() {
    let url = `http://localhost:3030/jsonstore/phonebook`;

    let createBtnElement = document.querySelector('#btnCreate');
    createBtnElement.addEventListener('click', createFunctionality);

    let loadBtnElement = document.querySelector('#btnLoad');
    loadBtnElement.addEventListener('click', loadFunctionality);

    function createFunctionality(e) {
        e.preventDefault();

        let personInputElement = document.querySelector('#person');
        let phoneInputElement = document.querySelector('#phone');

        fetch(url, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    person: personInputElement.value,
                    phone: phoneInputElement.value
                })
            })
            .then(res => res.json())
            .then(() => {
                loadBtnElement.click();
            });

        personInputElement.value = '';
        phoneInputElement.value = '';
    }

    function loadFunctionality(e) {
        e.preventDefault();

        let phonesListElement = document.querySelector('#phonebook');
        Array.from(phonesListElement.children).forEach(x => x.remove());

        fetch(url)
            .then(res => res.json())
            .then(phones => {
                Object.keys(phones)
                    .forEach(curr => {
                        createHtml(phones, curr);
                    })
            });
    }

    function createHtml(phones, curr) {
        let phonesListElement = document.querySelector('#phonebook');

        let liElement = document.createElement('li');
        liElement.textContent = `${phones[curr].person}: ${phones[curr].phone}`;
        liElement.setAttribute('id', phones[curr]._id);

        let deleteBtnElement = document.createElement('button');
        deleteBtnElement.textContent = 'Delete';
        deleteBtnElement.addEventListener('click', deleteFunctionality);

        liElement.appendChild(deleteBtnElement);

        phonesListElement.appendChild(liElement);
    }

    function deleteFunctionality(e) {
        e.preventDefault();

        let currElement = e.target.parentNode;
        let currElementId = currElement.id;

        fetch(`${url}/${currElementId}`, {
                method: 'DELETE'
            })
            .catch(err => { console.log(err) });

        currElement.remove();
    }
}

attachEvents();