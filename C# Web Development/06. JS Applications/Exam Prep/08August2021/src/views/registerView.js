import { html } from '../lib.js';

import * as authService from '../services/authService.js';

const registerTemplate = (onSubmit) => html `
    <!-- Register Page ( Only for Guest users ) -->
    <section id="register-page" class="register">
        <form id="register-form" action="" method="" @submit=${onSubmit}>
            <fieldset>
                <legend>Register Form</legend>
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
                <p class="field">
                    <label for="repeat-pass">Repeat Password</label>
                    <span class="input">
                        <input type="password" name="confirm-pass" id="repeat-pass" placeholder="Repeat Password">
                    </span>
                </p>
                <input class="button submit" type="submit" value="Register">
            </fieldset>
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
        let confirmPassword = formData.get('confirm-pass').trim();

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