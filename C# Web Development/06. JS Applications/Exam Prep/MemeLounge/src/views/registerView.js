import { html } from '../lib.js';

import * as authService from '../services/authService.js';

const registerTemplate = (onSubmit) => html `
    <!-- Register Page ( Only for guest users ) -->
    <section id="register">
        <form id="register-form" @submit=${onSubmit}>
            <div class="container">
                <h1>Register</h1>
                <label for="username">Username</label>
                <input id="username" type="text" placeholder="Enter Username" name="username">
                <label for="email">Email</label>
                <input id="email" type="text" placeholder="Enter Email" name="email">
                <label for="password">Password</label>
                <input id="password" type="password" placeholder="Enter Password" name="password">
                <label for="repeatPass">Repeat Password</label>
                <input id="repeatPass" type="password" placeholder="Repeat Password" name="repeatPass">
                <div class="gender">
                    <input type="radio" name="gender" id="female" value="female">
                    <label for="female">Female</label>
                    <input type="radio" name="gender" id="male" value="male" checked>
                    <label for="male">Male</label>
                </div>
                <input type="submit" class="registerbtn button" value="Register">
                <div class="container signin">
                    <p>Already have an account?<a href="/login">Sign in</a>.</p>
                </div>
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

        let username = formData.get('username').trim();
        let email = formData.get('email').trim();
        let password = formData.get('password').trim();
        let confirmPassword = formData.get('repeatPass').trim();
        let gender = formData.get('gender');

        if (!(username && email && password && confirmPassword)) {
            authService.getNotification('All fields must be filled!');
            // alert('All fields must be filled!');
            return;
        }

        if (password !== confirmPassword) {
            authService.getNotification('Passwords must match!');
            // alert('Passwords must match!');

            document.querySelector('#password').value = '';
            document.querySelector('#repeatPass').value = '';

            return;
        }

        authService.register(username, email, password, gender)
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