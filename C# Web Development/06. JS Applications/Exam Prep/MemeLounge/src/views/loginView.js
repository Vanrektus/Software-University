import { html } from '../lib.js';

import * as authService from '../services/authService.js';

const loginTemplate = (onSubmit) => html `
    <!-- Login Page ( Only for guest users ) -->
    <section id="login">
        <form id="login-form" @submit=${onSubmit}>
            <div class="container">
                <h1>Login</h1>
                <label for="email">Email</label>
                <input id="email" placeholder="Enter Email" name="email" type="text">
                <label for="password">Password</label>
                <input id="password" type="password" placeholder="Enter Password" name="password">
                <input type="submit" class="registerbtn button" value="Login">
                <div class="container signin">
                    <p>Dont have an account?<a href="/register">Sign up</a>.</p>
                </div>
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
            authService.getNotification('All fields must be filled!');
            // alert('All fields must be filled!');
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