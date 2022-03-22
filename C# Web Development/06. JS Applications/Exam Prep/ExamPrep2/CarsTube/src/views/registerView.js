import { html } from '../lib.js';

import * as authService from '../services/authService.js';

const registerTemplate = (onSubmit) => html `
    <!-- Register Page -->
    <section id="register">
        <div class="container">
            <form id="register-form" @submit=${onSubmit}>
                <h1>Register</h1>
                <p>Please fill in this form to create an account.</p>
                <hr>

                <p>Username</p>
                <input type="text" placeholder="Enter Username" name="username" required>

                <p>Password</p>
                <input type="password" placeholder="Enter Password" name="password" id="password" required>

                <p>Repeat Password</p>
                <input type="password" placeholder="Repeat Password" name="repeatPass" id="repeatPass" required>
                <hr>

                <input type="submit" class="registerbtn" value="Register">
            </form>
            <div class="signin">
                <p>Already have an account?
                    <a href="/login">Sign in</a>.
                </p>
            </div>
        </div>
    </section>
`;

export function registerPage(context) {
    let registerTemplateResult = registerTemplate(onSubmit);

    context.render(registerTemplateResult);

    function onSubmit(e) {
        e.preventDefault();

        let formData = new FormData(e.currentTarget);

        let username = formData.get('username').trim();
        let password = formData.get('password').trim();
        let confirmPassword = formData.get('repeatPass').trim();

        if (!(username && password && confirmPassword)) {
            alert('All fields must be filled!');
            return;
        }

        if (password !== confirmPassword) {
            alert('Passwords must match!');

            document.querySelector('#password').value = '';
            document.querySelector('#repeatPass').value = '';

            return;
        }

        authService.register(username, password)
            .then((data) => {
                if (data) {
                    throw new Error();
                }

                // alert('Successfull registration!');
                context.page.redirect('/');
            })
            .catch(() => {
                e.target.reset();
            });
    }
}