import { html, nothing } from '../lib.js';

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

const searchTemplate = (onSearchChange, onSearchClick, cars = []) => html `
    <!-- Search Page -->
    <section id="search-cars">
        <h1>Filter by year</h1>

        <div class="container">
            <input id="search-input" type="text" name="search" placeholder="Enter desired production year" @change=${onSearchChange}>
            <button class="button-list" @click=${onSearchClick}>Search</button>
        </div>

        <h2>Results:</h2>
        <div class="listings">
            ${cars.map(x => carCardTemplate(x))}

            ${cars.length == 0 ?  html`<p class="no-cars"> No results.</p>` : nothing}
        </div>
    </section>
`;

export function searchPage(context) {
    let currentSearchInput = '';

    let searchTemplateResult = searchTemplate(onSearchChange, onSearchClick);

    context.render(searchTemplateResult);
    
    function onSearchChange(e) {
        currentSearchInput = e.target.value;
    }

    function onSearchClick() {
        let year = Number(currentSearchInput);

        carService.getByYear(year)
        .then(cars => {
            let searchTemplateResult = searchTemplate(onSearchChange, onSearchClick, cars);

            context.render(searchTemplateResult);
        });
    }
}