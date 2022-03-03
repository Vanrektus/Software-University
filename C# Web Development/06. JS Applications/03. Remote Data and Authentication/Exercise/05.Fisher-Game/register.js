window.addEventListener('load', () => {
    let regUrl = 'http://localhost:3030/users/register';

    let loginBtnElement = document.querySelector('#login');
    loginBtnElement.setAttribute('class', 'hide');
    let registerBtnElement = document.querySelector('#register');
    registerBtnElement.setAttribute('class', 'hide');
    let logoutBtnElement = document.querySelector('#logout');
    logoutBtnElement.setAttribute('class', 'hide');

    let registerForm = document.querySelector('#register-view #register');
    registerForm.addEventListener('submit', registerFunctionality);

    function registerFunctionality(e) {
        e.preventDefault();

        let registerFormData = new FormData(e.target);

        let email = registerFormData.get('email');
        let password = registerFormData.get('password');
        let repeatPassword = registerFormData.get('rePass');

        if (!(email && password && repeatPassword)) {
            alert('All fields must be filled!');
            return;
        }

        if (password !== repeatPassword) {
            alert('Passwords must match!');

            document.querySelector('input[name=password]').value = '';
            document.querySelector('input[name=rePass]').value = '';

            return;
        }

        fetch(regUrl, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    email,
                    password
                })
            })
            .then(res => res.ok === true ? res.json() : res)
            .then(data => {
                if (data.ok === false) {
                    throw new Error();
                }

                saveToken(data._id, data.accessToken, data.email);

                alert('Successfull registration!');
                e.target.reset();
            })
            .catch(() => {
                e.target.reset();

                alert('This email is already registered!');
            });
    }

    function saveToken(id, accessToken, email) {
        const userData = {
            id,
            accessToken,
            email
        };

        localStorage.setItem('userData', JSON.stringify(userData));
    }
});