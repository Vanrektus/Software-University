window.addEventListener('load', () => {
    let loginUrl = 'http://localhost:3030/users/login';

    let loginBtnElement = document.querySelector('#login');
    loginBtnElement.setAttribute('class', 'hide');
    let registerBtnElement = document.querySelector('#register');
    registerBtnElement.setAttribute('class', 'hide');
    let logoutBtnElement = document.querySelector('#logout');
    logoutBtnElement.setAttribute('class', 'hide');

    let loginForm = document.querySelector('#login-view #login');
    loginForm.addEventListener('submit', loginFunctionality);

    function loginFunctionality(e) {
        e.preventDefault();

        let loginFormData = new FormData(e.currentTarget);

        let email = loginFormData.get('email');
        let password = loginFormData.get('password');

        if (!(email && password)) {
            alert('All fields must be filled!');
            return;
        }

        fetch(loginUrl, {
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

                alert('Successfull login!');
                e.target.reset();
                window.location = '/src/index.html';
            })
            .catch(() => {
                e.target.reset();

                alert('Incorrect email or password!');
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