import * as request from './requester.js';
import * as api from './api.js';

const USER_KEY = 'userData';

export function login(email, password) {
    return request.post(api.loginUrl, { email, password })
        .then(data => {
            if (data.code === 403) {
                throw new Error();
            }

            saveUserData(data);
        })
        .catch((error) => {
            alert('Incorrect login info!');
            return error;
        });
}

export function register(email, password) {
    return request.post(api.registerUrl, { email, password })
        .then(data => {
            if (data.code === 409) {
                throw new Error();
            }

            saveUserData(data);
        })
        .catch((error) => {
            alert('A user with the same email already exists!');
            return error;
        });
}

export function logout() {
    return request.get(api.logoutUrl)
        .finally(localStorage.removeItem(USER_KEY));
}

export function isAuthenticated() {
    let userData = getUserData();

    return Boolean(userData);
}

export function getUserData() {
    let userData = localStorage.getItem(USER_KEY);
    userData = JSON.parse(userData);

    return userData;
}

function saveUserData({ _id, accessToken, email, username, gender }) {
    const userData = {
        id: _id,
        accessToken,
        email,
        username,
        gender
    };

    localStorage.setItem(USER_KEY, JSON.stringify(userData));
}