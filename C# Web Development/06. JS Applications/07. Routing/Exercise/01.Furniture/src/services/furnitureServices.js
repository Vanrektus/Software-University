import { page } from "../lib.js";

const baseUrl = 'http://localhost:3030';

export function getService() {
    return fetch(`${baseUrl}/data/catalog`)
        .then(res => res.json());
}

export function createService(e, dataObj, accessToken) {
    fetch(`${baseUrl}/data/catalog`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'X-Authorization': accessToken
            },
            body: JSON.stringify(dataObj)
        })
        .then(res => res.json())
        .then(() => {
            e.target.parentNode.parentNode.parentNode.reset();
            alert('Furniture created successfully!');
            page.redirect('/');
        });
}

export function editService(e, dataObj, accessToken, id) {
    fetch(`${baseUrl}/data/catalog/${id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
                'X-Authorization': accessToken
            },
            body: JSON.stringify(dataObj)
        })
        .then(res => res.json())
        .then(() => {
            e.target.parentNode.parentNode.parentNode.reset();
            alert('Furniture successfully edited!');
            page.redirect('/');
        });
}

export function deleteService(accessToken, id) {
    fetch(`${baseUrl}/data/catalog/${id}`, {
        method: 'DELETE',
        headers: {
            'X-Authorization': accessToken
        }
    });
}