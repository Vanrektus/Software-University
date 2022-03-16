import { page } from '../lib.js';
import { loginService, registerService } from '../services/accountServices.js';
import { updateNavBar } from './api.js';

export function loginFunctionality(e) {
    e.preventDefault();

    let loginFormData = new FormData(e.target.parentNode.parentNode.parentNode);

    let email = loginFormData.get('email');
    let password = loginFormData.get('password');

    if (!(email && password)) {
        alert('All fields must be filled!');
        return;
    }

    let dataObj = {
        email,
        password
    };

    loginService(e, dataObj);
}

export function registerFunctionality(e) {
    e.preventDefault();

    let registerFormData = new FormData(e.target.parentNode.parentNode.parentNode);

    let email = registerFormData.get('email');
    let password = registerFormData.get('password');
    let repeatPassword = registerFormData.get('rePass');

    if (!(email && password && repeatPassword)) {
        alert('All fields must be filled!');
        return;
    }

    if (password !== repeatPassword) {
        alert('Passwords must match!');

        document.querySelector('input[name=password]').value = '';
        document.querySelector('input[name=rePass]').value = '';

        return;
    }

    const dataObj = {
        email,
        password
    };

    registerService(e, dataObj);
}

export function logoutFunctionality(e) {
    e.preventDefault();

    localStorage.clear();
    alert('Logout successfull!');
    page.redirect('/');
    updateNavBar();
}

export function saveToken(id, accessToken, email) {
    const userData = {
        id,
        accessToken,
        email
    };

    localStorage.setItem('userData', JSON.stringify(userData));
}