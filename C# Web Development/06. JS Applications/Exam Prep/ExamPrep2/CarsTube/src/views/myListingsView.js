import { html } from '../lib.js';

import * as carService from '../services/carService.js';

const carCardTemplate = (car) => html `
    <div class="listing">
        <div class="preview">
            <img src="${car.imageUrl}">
        </div>
        <h2>${car.brand} ${car.model}</h2>
        <div class="info">
            <div class="data-info">
                <h3>Year: ${car.year}</h3>
                <h3>Price: ${car.price} $</h3>
            </div>
            <div class="data-buttons">
                <a href="/listings/${car._id}" class="button-carDetails">Details</a>
            </div>
        </div>
    </div>
`;

const carListTemplate = (cars) => html `
    <!-- My Listings Page -->
    <section id="my-listings">
        <h1>My car listings</h1>
        <div class="listings">
            ${cars.length > 0 ? html`${cars.map(x => carCardTemplate(x))}` : html`<p class="no-cars"> You haven't listed any cars yet.</p>`}
        </div>
    </section>
`;

export function myListingsPage(context) {
    carService.getOnlyOwner(context.id)
        .then(cars => {
            let filteredCars = cars.filter(x => x._ownerId === context.id);

            let carListTemplateResult = carListTemplate(filteredCars);

            context.render(carListTemplateResult);
        })
}