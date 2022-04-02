import * as request from './requester.js';
import * as api from './api.js';

export function getAll() {
    return request.get(api.sortedPetsUrl);
}

// export function getOnlyOwner(userId) {
//     return request.get(`${api.booksUrl}?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
// }

export function getOne(petId) {
    return request.get(`${api.petsUrl}/${petId}`);
}

export function createPet(petInfo) {
    return request.post(api.petsUrl, petInfo);
}

export function editPet(petId, petInfo) {
    return request.put(`${api.petsUrl}/${petId}`, petInfo);
}

export function deletePet(petId) {
    return request.del(`${api.petsUrl}/${petId}`);
}

export function donateToAPet(petId) {
    return request.post(`${api.petLikesUrl}`, { petId });
}

export function specificUserDonations(petId, userId) {
    return request.get(`${api.petLikesUrl}?where=petId%3D%22${petId}%22%20and%20_ownerId%3D%22${userId}%22&count`);
}

export function getPetDonations(petId) {
    return request.get(`${api.petLikesUrl}?where=petId%3D%22${petId}%22&distinct=_ownerId&count`);
}