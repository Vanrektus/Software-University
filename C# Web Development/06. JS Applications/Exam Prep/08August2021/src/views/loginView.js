import { html } from '../lib.js';

import * as authService from '../services/authService.js';

const loginTemplate = (onSubmit) => html `
    <!-- Login Page ( Only for Guest users ) -->
    <section id="login-page" class="login">
        <form id="login-form" action="" method="" @submit=${onSubmit}>
            <fieldset>
                <legend>Login Form</legend>
                <p class="field">
                    <label for="email">Email</label>
                    <span class="input">
                        <input type="text" name="email" id="email" placeholder="Email">
                    </span>
                </p>
                <p class="field">
                    <label for="password">Password</label>
                    <span class="input">
                        <input type="password" name="password" id="password" placeholder="Password">
                    </span>
                </p>
                <input class="button submit" type="submit" value="Login">
            </fieldset>
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