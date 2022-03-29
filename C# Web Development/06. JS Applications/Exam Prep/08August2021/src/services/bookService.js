import * as request from './requester.js';
import * as api from './api.js';

export function getAll() {
    return request.get(api.sortedBooksUrl);
}

export function getOnlyOwner(userId) {
    return request.get(`${api.booksUrl}?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
}

export function getOne(bookId) {
    return request.get(`${api.booksUrl}/${bookId}`);
}

export function createBook(bookInfo) {
    return request.post(api.booksUrl, bookInfo);
}

export function editBook(bookId, bookInfo) {
    return request.put(`${api.booksUrl}/${bookId}`, bookInfo);
}

export function deleteBook(bookId) {
    return request.del(`${api.booksUrl}/${bookId}`);
}

export function likeABook(bookId) {
    return request.post(`${api.bookLikesUrl}`, { bookId });
}

export function specificUserLikes(bookId, userId) {
    return request.get(`${api.bookLikesUrl}?where=bookId%3D%22${bookId}%22%20and%20_ownerId%3D%22${userId}%22&count`);
}

export function getBookLikes(bookId) {
    return request.get(`${api.bookLikesUrl}?where=bookId%3D%22${bookId}%22&distinct=_ownerId&count`);
}