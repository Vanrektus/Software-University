function validate() {
    let companyElement = document.querySelector('#company');
    companyElement.addEventListener('change', () => {

        if (companyElement.checked) {
            document.querySelector('#companyInfo').style.display = 'block';
        } else {
            document.querySelector('#companyInfo').style.display = 'none';
        }
    });

    let submitButtonElement = document.querySelector('#submit');
    submitButtonElement.type = 'button';
    submitButtonElement.addEventListener('click', () => {

        let username = document.querySelector('#username');
        let email = document.querySelector('#email');
        let password = document.querySelector('#password');
        let confirmPassword = document.querySelector('#confirm-password');

        let validInputsArray = [];

        let usernameRegex = /^[a-zA-Z0-9]{3,20}$/;
        let emailRegex = /^[^@.]+@[^@]*\.[^@]*$/;
        let passwordRegex = /^[\w]{5,15}$/;

        if (!username.value.match(usernameRegex)) {
            username.style.borderColor = 'red';

            validInputsArray.push(false);
        } else {
            username.style.borderColor = '';
        }

        if (!email.value.match(emailRegex)) {
            email.style.borderColor = 'red';

            validInputsArray.push(false);
        } else {
            email.style.borderColor = '';
        }

        if (!(password.value.match(passwordRegex) && password.value === confirmPassword.value)) {
            password.style.borderColor = 'red';
            confirmPassword.style.borderColor = 'red';

            validInputsArray.push(false);
        } else {
            password.style.borderColor = '';
            confirmPassword.style.borderColor = '';
        }

        if (companyElement.checked) {
            let companyInfoElement = document.querySelector('#companyNumber');

            if (Number(companyInfoElement.value) < 1000 || Number(companyInfoElement.value) > 9999) {
                companyInfoElement.style.borderColor = 'red';

                validInputsArray.push(false);
            } else {
                companyInfoElement.style.borderColor = '';
            }
        }

        if (!validInputsArray.includes(false)) {
            document.querySelector('#valid').style.display = 'block';
        } else {
            document.querySelector('#valid').style.display = 'none';
        }
    });
}