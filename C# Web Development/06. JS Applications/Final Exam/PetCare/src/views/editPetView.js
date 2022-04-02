import { html } from '../lib.js';
import * as petService from '../services/petService.js';

const editPetTemplate = (pet, onSubmit) => html `
    <!--Edit Page-->
    <section id="editPage">
        <form class="editForm" @submit=${onSubmit}>
            <img src="${pet.image}">
            <div>
                <h2>Edit PetPal</h2>
                <div class="name">
                    <label for="name">Name:</label>
                    <input name="name" id="name" type="text" value="${pet.name}">
                </div>
                <div class="breed">
                    <label for="breed">Breed:</label>
                    <input name="breed" id="breed" type="text" value="${pet.breed}">
                </div>
                <div class="Age">
                    <label for="age">Age:</label>
                    <input name="age" id="age" type="text" value="${pet.age}">
                </div>
                <div class="weight">
                    <label for="weight">Weight:</label>
                    <input name="weight" id="weight" type="text" value="${pet.weight}">
                </div>
                <div class="image">
                    <label for="image">Image:</label>
                    <input name="image" id="image" type="text" value="${pet.image}">
                </div>
                <button class="btn" type="submit">Edit Pet</button>
            </div>
        </form>
    </section>
`;

export function editPetPage(context) {
    const petId = context.params.petId;

    petService.getOne(petId)
        .then(petInfo => {
            let editPetTemplateResult = editPetTemplate(petInfo, onSubmit);

            context.render(editPetTemplateResult);
        });

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

        petService.editPet(petId, petInfo)
            .then(() => {
                context.page.redirect(`/details/${petId}`);
            });
    }
}