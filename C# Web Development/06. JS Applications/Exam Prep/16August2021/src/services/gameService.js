import * as request from './requester.js';
import * as api from './api.js';

export function getAll() {
    return request.get(api.sortedGamesUrl);
}

export function getAllSorted() {
    return request.get(api.sortedCategoryGamesUrl);
}

export function getOnlyOwner(userId) {
    return request.get(`${api.gamesUrl}?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
}

export function getOne(gameId) {
    return request.get(`${api.gamesUrl}/${gameId}`);
}

export function createGame(gameInfo) {
    return request.post(api.gamesUrl, gameInfo);
}

export function editGame(gameId, gameInfo) {
    return request.put(`${api.gamesUrl}/${gameId}`, gameInfo);
}

export function deleteGame(gameId) {
    return request.del(`${api.gamesUrl}/${gameId}`);
}

export function getAllComments(gameId) {
    return request.get(`${api.gameCommentsUrl}?where=gameId%3D%22${gameId}%22`);
}

export function commentGame(commentInfo) {
    return request.post(`${api.gameCommentsUrl}`, commentInfo);
}