import { html } from '../lib.js';

import * as authService from '../services/authService.js';

const loginTemplate = (onSubmit) => html `
    <!-- Login Page ( Only for Guest users ) -->
    <section id="login-page" class="auth">
        <form id="login" @submit=${onSubmit}>

            <div class="container">
                <div class="brand-logo"></div>
                <h1>Login</h1>
                <label for="email">Email:</label>
                <input type="email" id="email" name="email" placeholder="Sokka@gmail.com">

                <label for="login-pass">Password:</label>
                <input type="password" id="login-password" name="password">
                <input type="submit" class="btn submit" value="Login">
                <p class="field">
                    <span>If you don't have profile click <a href="/register">here</a></span>
                </p>
            </div>
        </form>
    </section>
`;

export function loginPage(context) {
    let loginTemplateResult = loginTemplate(onSubmit);

    context.render(loginTemplateResult);

    function onSubmit(e) {
        e.preventDefault();

        let formData = new FormData(e.currentTarget);

        let email = formData.get('email').trim();
        let password = formData.get('password').trim();

        if (!(email && password)) {
            alert('All fields must be filled!');
            return;
        }

        authService.login(email, password)
            .then((data) => {
                if (data) {
                    throw new Error();
                }

                // alert('Successfull login!');
                context.page.redirect('/');
            })
            .catch(() => {
                e.target.reset();
            });
    }
}