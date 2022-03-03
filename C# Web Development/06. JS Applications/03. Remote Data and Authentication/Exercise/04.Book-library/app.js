window.onload = solve;

function solve() {
    let url = `http://localhost:3030/jsonstore/collections/books`;

    let tbodyElement = document.querySelector('tbody');

    let submitFormElement = document.querySelector('#create-form');
    submitFormElement.addEventListener('submit', submitFunctionality);
    let loadBooksButton = document.querySelector('#loadBooks');
    loadBooksButton.addEventListener('click', loadFunctionality);

    function submitFunctionality(e) {
        e.preventDefault();

        let submitForm = new FormData(e.currentTarget);
        let titleInput = submitForm.get('title');
        let authorInput = submitForm.get('author');

        if (!(titleInput && authorInput)) {
            return;
        }

        fetch(url, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    author: authorInput,
                    title: titleInput,
                })
            })
            .catch(err => { console.log(err); });

        loadFunctionality(e);
        e.currentTarget.reset();
    }

    function loadFunctionality(e) {
        e.preventDefault();

        fetch(url)
            .then(res => res.json())
            .then(books => {
                Array.from(tbodyElement.children).forEach(x => x.remove());

                Object.keys(books).forEach(curr => { createHtml(books, curr); });
            });
    }

    function createHtml(books, curr) {
        let trElement = document.createElement('tr');
        trElement.setAttribute('id', curr);

        let tdTitleElement = document.createElement('td');
        tdTitleElement.textContent = books[curr].title;

        let tdAuthorElement = document.createElement('td');
        tdAuthorElement.textContent = books[curr].author;

        let tdButtonsElement = document.createElement('td');

        let editBtnElement = document.createElement('button');
        editBtnElement.textContent = 'Edit';
        editBtnElement.addEventListener('click', editFunctionality);

        let deleteBtnElement = document.createElement('button');
        deleteBtnElement.textContent = 'Delete';
        deleteBtnElement.addEventListener('click', deleteFunctionality);

        tdButtonsElement.appendChild(editBtnElement);
        tdButtonsElement.appendChild(deleteBtnElement);

        trElement.appendChild(tdTitleElement);
        trElement.appendChild(tdAuthorElement);
        trElement.appendChild(tdButtonsElement);

        tbodyElement.appendChild(trElement);
    }

    function editFunctionality(e) {
        e.preventDefault();

        let editFormElement = document.querySelector('#edit-form');

        submitFormElement.setAttribute('class', 'hide');
        editFormElement.removeAttribute('class', 'hide');

        let titleInputElement = editFormElement.querySelector('input[name=title]');
        let authorInputElement = editFormElement.querySelector('input[name=author]');

        let currTitleElement = e.target.parentNode.previousSibling.previousSibling;
        let currAuthorElement = e.target.parentNode.previousSibling;

        titleInputElement.value = currTitleElement.textContent;
        authorInputElement.value = currAuthorElement.textContent;

        let currId = e.target.parentNode.parentNode.id;

        let saveEditBtnElement = document.querySelector('#save-edit');
        saveEditBtnElement.addEventListener('click', (e) => {
            e.preventDefault();

            let newTitleInputElement = editFormElement.querySelector('input[name=title]');
            let newAuthorInputElement = editFormElement.querySelector('input[name=author]');

            fetch(`${url}/${currId}`, {
                method: 'PUT',
                endpoint: `/jsonstore/books/${currId}`,
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    author: newAuthorInputElement.value,
                    title: newTitleInputElement.value
                })
            });

            newTitleInputElement.value = '';
            newAuthorInputElement.value = '';

            editFormElement.setAttribute('class', 'hide');
            submitFormElement.removeAttribute('class', 'hide');

            loadFunctionality(e);
        });
    }

    function deleteFunctionality(e) {
        e.preventDefault();

        let currElement = e.target.parentNode.parentNode;
        let currElementId = currElement.id;

        fetch(`${url}/${currElementId}`, {
            method: 'DELETE'
        })

        currElement.remove();
        loadFunctionality(e);
    }
}