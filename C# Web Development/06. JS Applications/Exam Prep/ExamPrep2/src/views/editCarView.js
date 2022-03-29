import { html } from '../lib.js';
import * as services from '../services/carService.js';

const editCarTemplate = (car, onSubmit) => html `
    <!-- Edit Listing Page -->
    <section id="edit-listing">
        <div class="container">

            <form id="edit-form" @submit=${onSubmit}>
                <h1>Edit Car Listing</h1>
                <p>Please fill in this form to edit an listing.</p>
                <hr>

                <p>Car Brand</p>
                <input type="text" placeholder="Enter Car Brand" name="brand" value="${car.brand}">

                <p>Car Model</p>
                <input type="text" placeholder="Enter Car Model" name="model" value="${car.model}">

                <p>Description</p>
                <input type="text" placeholder="Enter Description" name="description" value="${car.description}">

                <p>Car Year</p>
                <input type="number" placeholder="Enter Car Year" name="year" value="${car.year}">

                <p>Car Image</p>
                <input type="text" placeholder="Enter Car Image" name="imageUrl" value="${car.imageUrl}">

                <p>Car Price</p>
                <input type="number" placeholder="Enter Car Price" name="price" value="${car.price}">

                <hr>
                <input type="submit" class="registerbtn" value="Edit Listing">
            </form>
        </div>
    </section>
`;

export function editCarPage(context) {
    const carId = context.params.carId;

    services.getOne(carId)
        .then(carInfo => {
            let editCarTemplateResult = editCarTemplate(carInfo, onSubmit);

            context.render(editCarTemplateResult);
        });

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

        services.editCar(carId, carInfo)
            .then(() => {
                context.page.redirect('/listings');
            });
    }
}