import { html } from '../lib.js';

import * as authService from '../services/authService.js';

const registerTemplate = (onSubmit) => html `
    <div class="register-container"> 
        <h3>Register Page</h3>

        <form @submit="${onSubmit}">
            <div class="mb-3 row">
                <label for="email" class="col-sm-2 col-form-label">Email:</label>
                <div class="col-sm-10">
                    <input type="text" class="form-control" id="email" name="email">
                </div>
            </div>
            <div class="mb-3 row">
                <label for="username" class="col-sm-2 col-form-label">Username:</label>
                <div class="col-sm-10">
                    <input type="text" class="form-control" id="username" name="username">
                </div>
            </div>
            <div class="mb-3 row">
                <label for="password" class="col-sm-2 col-form-label">Password:</label>
                <div class="col-sm-10">
                    <input type="password" class="form-control" id="password" name="password">
                </div>
            </div>
            <div class="mb-3 row">
                <label for="confirmPassword" class="col-sm-2 col-form-label">Confirm Password:</label>
                <div class="col-sm-10">
                    <input type="password" class="form-control" id="confirmPassword" name="confirmPassword">
                </div>
            </div>
            <div class="mb-3 row">
                <div style="width: 200px;">
                    <input type="submit" class="btn btn-outline-primary">
                </div>
            </div>
        </form>
    </div>
`;

export function registerPage(context) {
    let registerTemplateResult = registerTemplate(onSubmit);

    context.render(registerTemplateResult);

    function onSubmit(e) {
        e.preventDefault();

        let formData = new FormData(e.currentTarget);

        let email = formData.get('email').trim();
        let username = formData.get('username').trim();
        let password = formData.get('password').trim();
        let confirmPassword = formData.get('confirmPassword').trim();

        if (!(email && username && password && confirmPassword)) {
            alert('All fields must be filled!');
            return;
        }

        if (password !== confirmPassword) {
            alert('Passwords must match!');

            document.querySelector('#password').value = '';
            document.querySelector('#confirmPassword').value = '';

            return;
        }

        authService.register(email, username, password)
            .then((data) => {
                if (data) {
                    throw new Error();
                }

                alert('Successfull registration!');
                context.page.redirect('/');
            })
            .catch(() => {
                e.target.reset();
            });
    }
}