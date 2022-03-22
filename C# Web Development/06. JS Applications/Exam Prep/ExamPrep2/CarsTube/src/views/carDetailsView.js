import { html, nothing } from '../lib.js';

import * as carService from '../services/carService.js';

const ownerBtnsTemplate = (deleteHandler, carId) => html `
    <div class="listings-buttons">
        <a href="/edit/${carId}" class="button-list">Edit</a>
        <a @click=${deleteHandler} href="#" class="button-list">Delete</a>
    </div>
`;

const carDetailsTemplate = (carInfo, isOwner, deleteHandler, carId) => html `
    <!-- Listing Details Page -->
    <section id="listing-details">
        <h1>Details</h1>
        <div class="details-info">
            <img src="${carInfo.imageUrl}">
            <hr>
            <ul class="listing-props">
                <li><span>Brand:</span>${carInfo.brand}</li>
                <li><span>Model:</span>${carInfo.model}</li>
                <li><span>Year:</span>${carInfo.year}</li>
                <li><span>Price:</span>${carInfo.price}$</li>
            </ul>

            <p class="description-para">${carInfo.description}</p>
            ${isOwner ? ownerBtnsTemplate(deleteHandler, carId) : nothing}
        </div>
    </section>
`;

export function carDetailsPage(context) {
    const carId = context.params.carId;

    carService.getOne(carId)
        .then(carInfo => {
            let isOwner = carInfo._ownerId === context.id;

            context.render(carDetailsTemplate(carInfo, isOwner, deleteHandler, carId));
        });

    function deleteHandler(e) {
        e.preventDefault();

        if (confirm('Are you sure you want ot delete this car?')) {
            carService.deleteCar(carId);
            context.page.redirect('/listings');
        }
    }
}