import { updateNavBar } from "../api/api.js";
import { saveToken } from "../api/accountApi.js";
import { page } from "../lib.js";

const baseUrl = 'http://localhost:3030';

export function loginService(e, dataObj) {
    fetch(`${baseUrl}/users/login`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(dataObj)
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

export function registerService(e, dataObj) {
    fetch(`${baseUrl}/users/register`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(dataObj)
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