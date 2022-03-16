// import { clearUserData, getUserData, setUserData } from '../util.js';
import { page } from '../lib.js';

const baseUrl = 'http://localhost:3030';

export function getProducts() {
    return fetch(`${baseUrl}/data/catalog`)
        .then(res => res.json());
}

export function loginFunctionality(e) {
    e.preventDefault();

    let loginFormData = new FormData(e.target.parentNode.parentNode.parentNode);

    let email = loginFormData.get('email');
    let password = loginFormData.get('password');

    if (!(email && password)) {
        alert('All fields must be filled!');
        return;
    }

    fetch(`${baseUrl}/users/login`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                email,
                password
            })
        })
        .then(res => res.ok === true ? res.json() : res)
        .then(data => {
            if (data.ok === false) {
                throw new Error();
            }
            saveToken(data._id, data.accessToken, data.email);

            alert('Successfull login!');
            e.target.parentNode.parentNode.parentNode.reset();
            page.redirect('/');
            updateNavBar();
        })
        .catch(() => {
            e.target.parentNode.parentNode.parentNode.reset();

            alert('Incorrect email or password!');
        });
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

    fetch(`${baseUrl}/users/register`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                email,
                password
            })
        })
        .then(res => res.ok === true ? res.json() : res)
        .then(data => {
            if (data.ok === false) {
                throw new Error();
            }

            saveToken(data._id, data.accessToken, data.email);

            alert('Successfull registration!');
            e.target.parentNode.parentNode.parentNode.reset();
            page.redirect('/');
            updateNavBar();
        })
        .catch(() => {
            e.target.parentNode.parentNode.parentNode.reset();

            alert('This email is already registered!');
        });
}

export function logoutFunctionality(e) {
    e.preventDefault();

    localStorage.clear();
    page.redirect('/');
    updateNavBar();
}

export function createFunctionality(e) {
    e.preventDefault();

    let createFormData = new FormData(e.target.parentNode.parentNode.parentNode);

    let make = createFormData.get('make');
    let model = createFormData.get('model');
    let year = createFormData.get('year');
    let description = createFormData.get('description');
    let price = createFormData.get('price');
    let img = createFormData.get('img');
    let material = createFormData.get('material');

    if (!(make && model && year && description && price && img)) {
        alert('All fields must be filled!');
        return;
    }

    if (make.length < 4) {
        alert('Make must be at least 4 symbols long!');
        return;
    }

    if (model.length < 4) {
        alert('Model must be at least 4 symbols long!');
        return;
    }

    if (year < 1950 || year > 2050) {
        alert('Year must be between 1950 and 2050!');
        return;
    }

    if (description.length < 10) {
        alert('Description must be at least 10 symbols long!');
        return;
    }

    if (price < 0) {
        alert('Price must be a positive number!');
        return;
    }

    let accessToken = JSON.parse(localStorage.getItem('userData')).accessToken;

    fetch(`${baseUrl}/data/catalog`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'X-Authorization': accessToken
            },
            body: JSON.stringify({
                make,
                model,
                year,
                description,
                price,
                img,
                material
            })
        })
        .then(res => res.json())
        .then(() => {
            e.target.parentNode.parentNode.parentNode.reset();
            page.redirect('/');
        });
}

export function isLoggedin() {
    let userData = localStorage.getItem('userData');

    return userData == null ? false : true;
}

export function updateNavBar() {
    const userData = localStorage.getItem('userData');

    userData ? document.querySelector('#guest').setAttribute('class', 'hidden') : document.querySelector('#guest').removeAttribute('class', 'hidden');
    userData ? document.querySelector('#user').removeAttribute('class', 'hidden') : document.querySelector('#user').setAttribute('class', 'hidden');
}

function saveToken(id, accessToken, email) {
    const userData = {
        id,
        accessToken,
        email
    };

    localStorage.setItem('userData', JSON.stringify(userData));
}