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
    <!-- All Listings Page -->
    <section id="car-listings">
        <h1>Car Listings</h1>
        <div class="listings">
            ${cars.length > 0 ? html`${cars.map(x => carCardTemplate(x))}` : html`<p class="no-cars">No cars in database.</p>`}
        </div>
    </section>
`;

export function listingsPage(context) {
    carService.getAll()
        .then(cars => {
            let filteredCars = cars;

            let carListTemplateResult = carListTemplate(filteredCars);

            context.render(carListTemplateResult);
        })
}