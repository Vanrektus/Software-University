window.addEventListener('load', () => {
    let baseUrl = 'http://localhost:3030';

    let loginBtnElement = document.querySelector('#login');
    let registerBtnElement = document.querySelector('#register');
    let logoutBtnElement = document.querySelector('#logout');
    logoutBtnElement.addEventListener('click', (e) => {
        e.preventDefault();

        localStorage.clear();
        location.reload();
    })

    let localStorageData = localStorage.getItem('userData');

    localStorageData ? logoutBtnElement.removeAttribute('class', 'hide') : logoutBtnElement.setAttribute('class', 'hide');
    localStorageData ? loginBtnElement.setAttribute('class', 'hide') : loginBtnElement.removeAttribute('class', 'hide');
    localStorageData ? registerBtnElement.setAttribute('class', 'hide') : registerBtnElement.removeAttribute('class', 'hide');

    let loggedUserWelcomeElement = document.querySelector('header span');
    localStorageData ? loggedUserWelcomeElement.textContent = JSON.parse(localStorageData).email : 'guest';

    let loadAllBtnElement = document.querySelector('.load');
    loadAllBtnElement.addEventListener('click', (e) => {
        fetch(`${baseUrl}/data/catches`)
            .then(res => res.json())
            .then(data => {
                Array.from(document.querySelector('#catches').children).forEach(x => x.remove());

                Object.keys(data).forEach(x => {
                    createCatchHtml(data, x);
                });
            });
    });

    let addForm = document.querySelector('#addForm');
    !localStorageData ? addForm.querySelectorAll('input').forEach(x => x.setAttribute('disabled', true)) : addForm;
    localStorageData ? addForm.querySelector('button').removeAttribute('disabled') : addForm;

    addForm.addEventListener('submit', (e) => {
        e.preventDefault();

        let addFormData = new FormData(addForm);

        let angler = addFormData.get('angler');
        let weight = addFormData.get('weight');
        let species = addFormData.get('species');
        let location = addFormData.get('location');
        let bait = addFormData.get('bait');
        let captureTime = addFormData.get('captureTime');

        if (!(angler && weight && species && location && bait && captureTime)) {
            alert('All fields must be filled!');
            return;
        }

        let accessToken = JSON.parse(localStorageData).accessToken;

        fetch(`${baseUrl}/data/catches`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    'X-Authorization': accessToken
                },
                body: JSON.stringify({
                    angler,
                    weight,
                    species,
                    location,
                    bait,
                    captureTime
                })
            })
            .then(res => res.json())
            .then(data => {
                addForm.reset();
            })
            .catch(err => {
                alert(err);
            });
    });

    function updateFunctionality(e) {
        e.preventDefault();

        let anglerInput = e.target.parentNode.querySelector('.angler');
        let weightInput = e.target.parentNode.querySelector('.weight');
        let speciesInput = e.target.parentNode.querySelector('.species');
        let locationInput = e.target.parentNode.querySelector('.location');
        let baitInput = e.target.parentNode.querySelector('.bait');
        let captureTimeInput = e.target.parentNode.querySelector('.captureTime');

        if (!(anglerInput.value &&
                weightInput.value &&
                speciesInput.value &&
                locationInput.value &&
                baitInput.value &&
                captureTimeInput.value)) {
            alert('All fields must be filled!');
            return;
        }

        let currId = e.target.getAttribute('data-id');
        let accessToken = JSON.parse(localStorageData).accessToken;

        fetch(`${baseUrl}/data/catches/${currId}`, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                    'X-Authorization': accessToken
                },
                body: JSON.stringify({
                    angler: anglerInput.value,
                    weight: weightInput.value,
                    species: speciesInput.value,
                    location: locationInput.value,
                    bait: baitInput.value,
                    captureTime: captureTimeInput.value
                })
            })
            .catch(err => {
                alert(err);
            });
    }

    function deleteFunctionality(e) {
        e.preventDefault();

        let currElement = e.target.parentNode;
        let currId = e.target.getAttribute('data-id');
        let accessToken = JSON.parse(localStorageData).accessToken;

        fetch(`${baseUrl}/data/catches/${currId}`, {
            method: 'DELETE',
            headers: {
                'X-Authorization': accessToken
            }
        });

        currElement.remove();
    }

    function createCatchHtml(data, x) {
        let divElement = document.createElement('div');
        divElement.setAttribute('class', 'catch');

        // Angler
        let anglerLabel = document.createElement('label');
        anglerLabel.textContent = 'Angler';

        let anglerInput = document.createElement('input');
        anglerInput.setAttribute('type', 'text');
        anglerInput.setAttribute('class', 'angler');
        anglerInput.setAttribute('value', `${data[x].angler}`);

        // Weight
        let weightLabel = document.createElement('label');
        weightLabel.textContent = 'Weight';

        let weightInput = document.createElement('input');
        weightInput.setAttribute('type', 'text');
        weightInput.setAttribute('class', 'weight');
        weightInput.setAttribute('value', `${data[x].weight}`);

        // Species
        let speciesLabel = document.createElement('label');
        speciesLabel.textContent = 'Species';

        let speciesInput = document.createElement('input');
        speciesInput.setAttribute('type', 'text');
        speciesInput.setAttribute('class', 'species');
        speciesInput.setAttribute('value', `${data[x].species}`);

        // Location
        let locationLabel = document.createElement('label');
        locationLabel.textContent = 'Location';

        let locationInput = document.createElement('input');
        locationInput.setAttribute('type', 'text');
        locationInput.setAttribute('class', 'location');
        locationInput.setAttribute('value', `${data[x].location}`);

        // Bait
        let baitLabel = document.createElement('label');
        baitLabel.textContent = 'Bait';

        let baitInput = document.createElement('input');
        baitInput.setAttribute('type', 'text');
        baitInput.setAttribute('class', 'bait');
        baitInput.setAttribute('value', `${data[x].bait}`);

        // Capture Time
        let captureTimeLabel = document.createElement('label');
        captureTimeLabel.textContent = 'Capture Time';

        let captureTimeInput = document.createElement('input');
        captureTimeInput.setAttribute('type', 'number');
        captureTimeInput.setAttribute('class', 'captureTime');
        captureTimeInput.setAttribute('value', `${data[x].captureTime}`);

        // Buttons
        let updateButton = document.createElement('button');
        updateButton.setAttribute('class', 'update');
        updateButton.setAttribute('data-id', `${data[x]._id}`);
        updateButton.textContent = 'Update';
        updateButton.addEventListener('click', updateFunctionality);

        let deleteButton = document.createElement('button');
        deleteButton.setAttribute('class', 'delete');
        deleteButton.setAttribute('data-id', `${data[x]._id}`);
        deleteButton.textContent = 'Delete';
        deleteButton.addEventListener('click', deleteFunctionality);

        // Append
        divElement.appendChild(anglerLabel);
        divElement.appendChild(anglerInput);

        divElement.appendChild(weightLabel);
        divElement.appendChild(weightInput);

        divElement.appendChild(speciesLabel);
        divElement.appendChild(speciesInput);

        divElement.appendChild(locationLabel);
        divElement.appendChild(locationInput);

        divElement.appendChild(baitLabel);
        divElement.appendChild(baitInput);

        divElement.appendChild(captureTimeLabel);
        divElement.appendChild(captureTimeInput);

        divElement.appendChild(updateButton);
        divElement.appendChild(deleteButton);

        // Enable/Disable Inputs
        if (!localStorageData || (localStorageData && JSON.parse(localStorageData).id !== data[x]._ownerId)) {
            let allInputElements = divElement.querySelectorAll('input');
            allInputElements.forEach(x => x.setAttribute('disabled', true));

            let allButtonElements = divElement.querySelectorAll('button');
            allButtonElements.forEach(x => x.setAttribute('disabled', true));
        }

        let mainDivElement = document.querySelector('#catches');
        mainDivElement.appendChild(divElement);
    }
});