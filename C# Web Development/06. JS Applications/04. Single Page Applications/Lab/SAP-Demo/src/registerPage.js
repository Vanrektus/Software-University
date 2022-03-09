import { saveToken } from './auth.js';

let baseUrl = 'http://localhost:3030';

let registerSection = document.querySelector('section.register');
let registerForm = document.querySelector('#register-form');
registerForm.addEventListener('submit', (e) => {
    e.preventDefault();

    let formData = new FormData(e.target);

    fetch(`${baseUrl}/users/register`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: {
                email: formData.get('email'),
                username: formData.get('username'),
                password: formData.get('password'),
                confirmPassword: formData.get('confirmPassword'),
            }
        })
        .then(res => res.json())
        .then(data => {
            console.log(data);
            saveToken(data.accessToken);
        });
})

function showPage() {
    registerSection.removeAttribute('class', 'hidden');
}

function hidePage() {
    registerSection.setAttribute('class', 'hidden');
}

export default {
    showPage,
    hidePage,
}