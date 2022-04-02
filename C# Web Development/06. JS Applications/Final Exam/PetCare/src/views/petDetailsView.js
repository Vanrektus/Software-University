import { html, nothing } from '../lib.js';

import * as petService from '../services/petService.js';

const ownerBtnsTemplate = (deleteHandler, petId) => html `
    <!-- Only for registered user and creator of the pets-->
    <a href="/edit/${petId}" class="edit">Edit</a>
    <a href="#" class="remove" @click=${deleteHandler}>Delete</a>
`;

const petDetailsTemplate = (petInfo, isOwner, deleteHandler, petId, isAuthenticated, onDonationClick, petDonations, hasUserDonated) => html `
    <!--Details Page-->
    <section id="detailsPage">
        <div class="details">
            <div class="animalPic">
                <img src="${petInfo.image}">
            </div>
            <div>
                <div class="animalInfo">
                    <h1>Name: ${petInfo.name}</h1>
                    <h3>Breed: ${petInfo.breed}</h3>
                    <h4>Age: ${petInfo.age} years</h4>
                    <h4>Weight: ${petInfo.weight}kg</h4>
                    <h4 class="donation">Donation: ${petDonations * 100}$</h4>
                </div>
                <!-- if there is no registered user, do not display div-->
                <div class="actionBtn">
                    ${isOwner ? ownerBtnsTemplate(deleteHandler, petId) : nothing}
                    <!--(Bonus Part) Only for no creator and user-->
                    ${isAuthenticated && !isOwner && !hasUserDonated ? html`<a href="#" class="donate" @click=${onDonationClick}>Donate</a>` : nothing}                    
                </div>
            </div>
        </div>
    </section>
`;

export async function petDetailsPage(context) {
    const petId = context.params.petId;

    // let bookInfo = await bookService.getOne(bookId);
    // let isOwner = bookInfo._ownerId === context.id;
    // let numOfLikes = await bookService.getBookLikes(bookId);
    // let hasUserLiked = await bookService.specificUserLikes(bookId, context.id) > 0;

    // context.render(bookDetailsTemplate(bookInfo, isOwner, deleteHandler, bookId, context.isAuthenticated, onLikeClick, numOfLikes, hasUserLiked));

    petService.getOne(petId)
        .then(petInfo => {
            let isOwner = petInfo._ownerId === context.id;

            petService.getPetDonations(petId)
                .then(donations => {

                    petService.specificUserDonations(petId, context.id)
                        .then((userDonations) => {
                            let hasUserDonated = userDonations > 0;
                            context.render(petDetailsTemplate(petInfo, isOwner, deleteHandler, petId, context.isAuthenticated, onDonationClick, donations, hasUserDonated));
                        });
                });
        });

    function deleteHandler(e) {
        e.preventDefault();

        if (confirm('Are you sure you want to delete this pet?')) {
            petService.deletePet(petId);
            context.page.redirect('/');
        }
    }

    function onDonationClick(e) {
        e.preventDefault();

        petService.donateToAPet(petId);

        context.page.redirect(`/details/${petId}`);
    }
}