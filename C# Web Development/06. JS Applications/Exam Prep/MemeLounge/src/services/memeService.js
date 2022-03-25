import * as request from './requester.js';
import * as api from './api.js';

export function getAll() {
    return request.get(api.sortedMemesUrl);
}

export function getOnlyOwner(userId) {
    return request.get(`${api.memesUrl}?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
}

export function getOne(memeId) {
    return request.get(`${api.memesUrl}/${memeId}`);
}

export function createMeme(memeInfo) {
    return request.post(api.memesUrl, memeInfo);
}

export function editMeme(memeId, memeInfo) {
    return request.put(`${api.memesUrl}/${memeId}`, memeInfo);
}

export function deleteMeme(memeId) {
    return request.del(`${api.memesUrl}/${memeId}`);
}