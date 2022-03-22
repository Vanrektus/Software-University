import { html } from '../lib.js';

import * as authService from '../services/authService.js';

const loginTemplate = (onSubmit) => html `
    <!-- Login Page -->
    <section id="login">
        <div class="container">
            <form id="login-form" action="#" method="post" @submit=${onSubmit}>
                <h1>Login</h1>
                <p>Please enter your credentials.</p>
                <hr>

                <p>Username</p>
                <input placeholder="Enter Username" name="username" type="text">

                <p>Password</p>
                <input type="password" placeholder="Enter Password" name="password">
                <input type="submit" class="registerbtn" value="Login">
            </form>
            <div class="signin">
                <p>Dont have an account?
                    <a href="/register">Sign up</a>.
                </p>
            </div>
        </div>
    </section>
`;

export function loginPage(context) {
    let loginTemplateResult = loginTemplate(onSubmit);

    context.render(loginTemplateResult);

    function onSubmit(e) {
        e.preventDefault();

        let formData = new FormData(e.currentTarget);

        let username = formData.get('username').trim();
        let password = formData.get('password').trim();

        if (!(username && password)) {
            alert('All fields must be filled!');
            return;
        }

        authService.login(username, password)
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