import * as request from './requester.js';
import * as api from './api.js';

export function getAll() {
    return request.get(api.moviesUrl);
}

export function getOne(movieId) {
    return request.get(`${api.moviesUrl}/${movieId}`);
}

export function addMovie(movieInfo) {
    return request.post(api.moviesUrl, movieInfo);
}

export function editMovie(movieId, movieInfo) {
    return request.put(`${api.moviesUrl}/${movieId}`, movieInfo);
}

export function deleteMovie(movieId) {
    return request.del(`${api.moviesUrl}/${movieId}`);
}