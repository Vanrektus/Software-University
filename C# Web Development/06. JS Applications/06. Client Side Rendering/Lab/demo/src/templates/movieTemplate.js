import { html } from "../../node_modules/lit-html/lit-html.js";

export default (movie) => html ` 
    <li class="movie-item" style="width: 18rem;">
        <img src="${movie.imageSrc}" class="card-img-top" alt="Missing Image">
        <div class="card-body">
            <h5 class="card-title">${movie.title}</h5>
            <p class="card-text">${movie.description}</p>
            <a href="#" @click=${movie.onDetailsClick} class="btn btn-primary">Show Details</a>
        </div>
    </li>
`;