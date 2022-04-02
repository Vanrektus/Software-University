import { html } from '../lib.js';

import * as authService from '../services/authService.js';

const loginTemplate = (onSubmit) => html `
    <!--Login Page-->
    <section id="loginPage">
        <form class="loginForm" @submit=${onSubmit}>
            <img src="./images/logo.png" alt="logo" />
            <h2>Login</h2>

            <div>
                <label for="email">Email:</label>
                <input id="email" name="email" type="text" placeholder="steven@abv.bg" value="">
            </div>

            <div>
                <label for="password">Password:</label>
                <input id="password" name="password" type="password" placeholder="********" value="">
            </div>

            <button class="btn" type="submit">Login</button>

            <p class="field">
                <span>If you don't have profile click <a href="/register">here</a></span>
            </p>
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