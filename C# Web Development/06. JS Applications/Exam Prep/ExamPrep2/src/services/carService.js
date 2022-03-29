import * as request from './requester.js';
import * as api from './api.js';

export function getAll() {
    return request.get(api.sortedListingsUrl);
}

export function getOnlyOwner(userId) {
    return request.get(`${api.listingsUrl}?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
}

export function getByYear(year) {
    return request.get(`${api.listingsUrl}?where=year%3D${year}`);
}

export function getOne(carId) {
    return request.get(`${api.listingsUrl}/${carId}`);
}

export function addCar(carInfo) {
    return request.post(api.listingsUrl, carInfo);
}

export function editCar(carId, carInfo) {
    return request.put(`${api.listingsUrl}/${carId}`, carInfo);
}

export function deleteCar(carId) {
    return request.del(`${api.listingsUrl}/${carId}`);
}