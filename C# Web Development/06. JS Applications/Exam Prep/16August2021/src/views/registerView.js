import { html } from '../lib.js';

import * as authService from '../services/authService.js';

const registerTemplate = (onSubmit) => html `
    <!-- Register Page ( Only for Guest users ) -->
    <section id="register-page" class="content auth">
        <form id="register" @submit=${onSubmit}>
            <div class="container">
                <div class="brand-logo"></div>
                <h1>Register</h1>

                <label for="email">Email:</label>
                <input type="email" id="email" name="email" placeholder="maria@email.com">

                <label for="pass">Password:</label>
                <input type="password" name="password" id="register-password">

                <label for="con-pass">Confirm Password:</label>
                <input type="password" name="confirm-password" id="confirm-password">

                <input class="btn submit" type="submit" value="Register">

                <p class="field">
                    <span>If you already have profile click <a href="#">here</a></span>
                </p>
            </div>
        </form>
    </section>
`;

export function registerPage(context) {
    let registerTemplateResult = registerTemplate(onSubmit);

    context.render(registerTemplateResult);

    function onSubmit(e) {
        e.preventDefault();

        let formData = new FormData(e.currentTarget);

        let email = formData.get('email').trim();
        let password = formData.get('password').trim();
        let confirmPassword = formData.get('confirm-password').trim();

        if (!(email && password && confirmPassword)) {
            alert('All fields must be filled!');
            return;
        }

        if (password !== confirmPassword) {
            alert('Passwords must match!');

            document.querySelector('#password').value = '';
            document.querySelector('#repeat-pass').value = '';

            return;
        }

        authService.register(email, password)
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