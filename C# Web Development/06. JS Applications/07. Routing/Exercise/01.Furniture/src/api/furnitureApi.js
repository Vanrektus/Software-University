import { page } from '../lib.js';
import { createService, deleteService, editService } from '../services/furnitureServices.js';

export function createFunctionality(e) {
    e.preventDefault();

    let createFormData = new FormData(e.target.parentNode.parentNode.parentNode);

    let formFuncResult = formFunctionality(createFormData);

    if (!formFuncResult) {
        return;
    }

    let dataObj = formFuncResult.dataObj;
    let accessToken = formFuncResult.accessToken;

    createService(e, dataObj, accessToken);
}

export function saveEditFunctionality(e) {
    e.preventDefault();

    let createFormData = new FormData(e.target.parentNode.parentNode.parentNode);

    let formFuncResult = formFunctionality(createFormData);

    if (!formFuncResult) {
        return;
    }

    let dataObj = formFuncResult.dataObj;
    let accessToken = formFuncResult.accessToken;

    let saveEditBtn = document.querySelector('.btn-info');

    editService(e, dataObj, accessToken, saveEditBtn.id);
}

export function deleteFunctionality(e) {
    e.preventDefault();

    const userDataAccToken = JSON.parse(localStorage.getItem('userData')).accessToken;
    let currFurnitureId = e.target.id;

    let confirmText = "Are you sure you want to delete this furniture?";
    if (confirm(confirmText) != true) {
        return;
    }

    deleteService(userDataAccToken, currFurnitureId);
    page.redirect('/');
}

function formFunctionality(createFormData) {
    let make = createFormData.get('make');
    let model = createFormData.get('model');
    let year = createFormData.get('year');
    let description = createFormData.get('description');
    let price = createFormData.get('price');
    let img = createFormData.get('img');
    let material = createFormData.get('material');

    if (!(make && model && year && description && price && img)) {
        alert('All fields must be filled!');
        return;
    }

    if (make.length < 4) {
        alert('Make must be at least 4 symbols long!');
        return;
    }

    if (model.length < 4) {
        alert('Model must be at least 4 symbols long!');
        return;
    }

    if (year < 1950 || year > 2050) {
        alert('Year must be between 1950 and 2050!');
        return;
    }

    if (description.length < 10) {
        alert('Description must be at least 10 symbols long!');
        return;
    }

    if (price < 0) {
        alert('Price must be a positive number!');
        return;
    }

    let dataObj = {
        make,
        model,
        year,
        description,
        price,
        img,
        material
    };
    let accessToken = JSON.parse(localStorage.getItem('userData')).accessToken;

    return {
        dataObj,
        accessToken
    };
}