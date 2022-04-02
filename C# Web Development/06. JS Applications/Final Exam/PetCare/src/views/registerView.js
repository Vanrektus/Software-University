import { html } from '../lib.js';

import * as authService from '../services/authService.js';

const registerTemplate = (onSubmit) => html `
    <!--Register Page-->
    <section id="registerPage">
        <form class="registerForm" @submit=${onSubmit}>
            <img src="./images/logo.png" alt="logo" />
            <h2>Register</h2>
            <div class="on-dark">
                <label for="email">Email:</label>
                <input id="email" name="email" type="text" placeholder="steven@abv.bg" value="">
            </div>

            <div class="on-dark">
                <label for="password">Password:</label>
                <input id="password" name="password" type="password" placeholder="********" value="">
            </div>

            <div class="on-dark">
                <label for="repeatPassword">Repeat Password:</label>
                <input id="repeatPassword" name="repeatPassword" type="password" placeholder="********" value="">
            </div>

            <button class="btn" type="submit">Register</button>

            <p class="field">
                <span>If you have profile click <a href="/login">here</a></span>
            </p>
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
        let confirmPassword = formData.get('repeatPassword').trim();

        if (!(email && password && confirmPassword)) {
            alert('All fields must be filled!');
            return;
        }

        if (password !== confirmPassword) {
            alert('Passwords must match!');

            document.querySelector('#password').value = '';
            document.querySelector('#repeatPassword').value = '';

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