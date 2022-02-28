function lockedProfile() {
    let mainSectionElement = document.querySelector('#main');

    let firstEmptyProfile = document.querySelector('.profile');
    firstEmptyProfile.remove();

    let baseUrl = `http://localhost:3030/jsonstore/advanced/profiles`;

    fetch(baseUrl)
        .then(res => res.json())
        .then(profiles => {
            Object.keys(profiles).forEach((key, i) => {
                let profile = profiles[key];
                createHtmlProfile(i + 1, profile.username, profile.email, profile.age);
            });
        });

    function createHtmlProfile(userIndex, username, email, age) {
        let profileDivElement = document.createElement('div');
        profileDivElement.setAttribute('class', 'profile');

        let profileImgElement = document.createElement('img');
        profileImgElement.setAttribute('src', './iconProfile2.png');
        profileImgElement.setAttribute('class', 'userIcon');

        let lockLabelElement = document.createElement('label');
        lockLabelElement.textContent = 'Lock';

        let lockRadioElement = document.createElement('input');
        lockRadioElement.setAttribute('type', 'radio');
        lockRadioElement.setAttribute('name', `user${userIndex}Locked`);
        lockRadioElement.setAttribute('value', 'lock');
        lockRadioElement.setAttribute('checked', true);

        let unlockLabelElement = document.createElement('label');
        unlockLabelElement.textContent = 'Unlock';

        let unlockRadioElement = document.createElement('input');
        unlockRadioElement.setAttribute('type', 'radio');
        unlockRadioElement.setAttribute('name', `user${userIndex}Locked`);
        unlockRadioElement.setAttribute('value', 'unlock');

        let brElement = document.createElement('br');
        let hrElement = document.createElement('hr');

        let usernameLabelElement = document.createElement('label');
        usernameLabelElement.textContent = 'Username';

        let usernameInputElement = document.createElement('input');
        usernameInputElement.setAttribute('name', `user${userIndex}Username`);
        usernameInputElement.setAttribute('value', username);
        usernameInputElement.setAttribute('readOnly', true);
        usernameInputElement.setAttribute('disabled', true);

        let hiddenFieldsDiv = document.createElement('div');
        hiddenFieldsDiv.textContent = `user${userIndex}HiddenFields`;
        hiddenFieldsDiv.style.display = 'none';

        let hiddenFieldsHr = document.createElement('hr');

        let emailLabelElement = document.createElement('label');
        emailLabelElement.textContent = `Email: `;

        let emailInputElement = document.createElement('input');
        emailInputElement.setAttribute('type', 'email');
        emailInputElement.setAttribute('name', `user${userIndex}Email`);
        emailInputElement.setAttribute('value', email);
        emailInputElement.setAttribute('readOnly', true);
        emailInputElement.setAttribute('disabled', true);

        let ageLabelElement = document.createElement('label');
        ageLabelElement.textContent = `Age: `;

        let ageInputElement = document.createElement('input');
        ageInputElement.setAttribute('type', 'email');
        ageInputElement.setAttribute('name', `user${userIndex}Age`);
        ageInputElement.setAttribute('value', age);
        ageInputElement.setAttribute('readOnly', true);
        ageInputElement.setAttribute('disabled', true);

        let showMoreButtonElement = document.createElement('button');
        showMoreButtonElement.textContent = 'Show More';
        showMoreButtonElement.addEventListener('click', showMoreFunction);

        hiddenFieldsDiv.appendChild(hiddenFieldsHr);
        hiddenFieldsDiv.appendChild(emailLabelElement);
        hiddenFieldsDiv.appendChild(emailInputElement);
        hiddenFieldsDiv.appendChild(ageLabelElement);
        hiddenFieldsDiv.appendChild(ageInputElement);

        profileDivElement.appendChild(profileImgElement);
        profileDivElement.appendChild(lockLabelElement);
        profileDivElement.appendChild(lockRadioElement);
        profileDivElement.appendChild(unlockLabelElement);
        profileDivElement.appendChild(unlockRadioElement);
        profileDivElement.appendChild(brElement);
        profileDivElement.appendChild(hrElement);
        profileDivElement.appendChild(usernameLabelElement);
        profileDivElement.appendChild(usernameInputElement);
        profileDivElement.appendChild(hiddenFieldsDiv);
        profileDivElement.appendChild(showMoreButtonElement);

        mainSectionElement.appendChild(profileDivElement);
    }

    function showMoreFunction(e) {
        let profile = e.target.parentNode;
        let showMoreButton = e.target;
        let hiddenFieldsDiv = e.target.previousSibling;
        let radioButton = profile.querySelector('input[type="radio"]:checked');

        if (radioButton.value !== 'unlock') {
            return;
        }

        showMoreButton.textContent = showMoreButton.textContent === 'Show More' ? 'Hide it' : 'Show More';

        hiddenFieldsDiv.style.display = hiddenFieldsDiv.style.display === 'block' ? 'none' : 'block';
    }
}