import { html } from '../lib.js';
import * as petService from '../services/petService.js';

const createPetTemplate = (onSubmit) => html `
    <!--Create Page-->
    <section id="createPage">
        <form class="createForm" @submit=${onSubmit}>
            <img src="./images/cat-create.jpg">
            <div>
                <h2>Create PetPal</h2>
                <div class="name">
                    <label for="name">Name:</label>
                    <input name="name" id="name" type="text" placeholder="Max">
                </div>
                <div class="breed">
                    <label for="breed">Breed:</label>
                    <input name="breed" id="breed" type="text" placeholder="Shiba Inu">
                </div>
                <div class="Age">
                    <label for="age">Age:</label>
                    <input name="age" id="age" type="text" placeholder="2 years">
                </div>
                <div class="weight">
                    <label for="weight">Weight:</label>
                    <input name="weight" id="weight" type="text" placeholder="5kg">
                </div>
                <div class="image">
                    <label for="image">Image:</label>
                    <input name="image" id="image" type="text" placeholder="./image/dog.jpeg">
                </div>
                <button class="btn" type="submit">Create Pet</button>
            </div>
        </form>
    </section>
`;

export function createPetPage(context) {
    let createPetTemplateResult = createPetTemplate(onSubmit);

    context.render(createPetTemplateResult);

    function onSubmit(e) {
        e.preventDefault();

        let petDataInput = Object.fromEntries(new FormData(e.currentTarget));

        if (!(petDataInput.name &&
                petDataInput.breed &&
                petDataInput.age &&
                petDataInput.weight &&
                petDataInput.image)) {
            alert('All fields must be filled!');
            return;
        }

        let petInfo = {
            name: petDataInput.name,
            breed: petDataInput.breed,
            age: petDataInput.age,
            weight: petDataInput.weight,
            image: petDataInput.image,
        }

        petService.createPet(petInfo)
            .then(() => {
                context.page.redirect('/');
            });
    }
}