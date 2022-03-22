import { html } from '../lib.js';
import * as services from '../services/carService.js';

const addCarTemplate = (onSubmit) => html `
    <!-- Create Listing Page -->
    <section id="create-listing">
        <div class="container">
            
            <form id="create-form" @submit=${onSubmit}>
                <h1>Create Car Listing</h1>
                <p>Please fill in this form to create an listing.</p>
                <hr>

                <p>Car Brand</p>
                <input type="text" placeholder="Enter Car Brand" name="brand">

                <p>Car Model</p>
                <input type="text" placeholder="Enter Car Model" name="model">

                <p>Description</p>
                <input type="text" placeholder="Enter Description" name="description">

                <p>Car Year</p>
                <input type="number" placeholder="Enter Car Year" name="year">

                <p>Car Image</p>
                <input type="text" placeholder="Enter Car Image" name="imageUrl">

                <p>Car Price</p>
                <input type="number" placeholder="Enter Car Price" name="price">

                <hr>
                <input type="submit" class="registerbtn" value="Create Listing">
            </form>
        </div>
    </section>
`;

export function addCarPage(context) {
    let addCarTemplateResult = addCarTemplate(onSubmit);

    context.render(addCarTemplateResult);

    function onSubmit(e) {
        e.preventDefault();

        let carDataInput = Object.fromEntries(new FormData(e.currentTarget));

        carDataInput.year = Number(carDataInput.year);
        carDataInput.price = Number(carDataInput.price);

        if (!(carDataInput.brand &&
                carDataInput.model &&
                carDataInput.description &&
                carDataInput.year &&
                carDataInput.imageUrl &&
                carDataInput.price)) {
            console.log('All fields must be filled!');
            return;
        }

        if (carDataInput.year < 0) {
            console.log('Year must be a positive number!');
            return;
        }

        if (carDataInput.price < 0) {
            console.log('Price must e a positive number!');
            return;
        }

        let carInfo = {
            brand: carDataInput.brand,
            model: carDataInput.model,
            description: carDataInput.description,
            year: carDataInput.year,
            imageUrl: carDataInput.imageUrl,
            price: carDataInput.price
        }

        services.addCar(carInfo)
            .then(() => {
                context.page.redirect('/listings');
            });
    }
}