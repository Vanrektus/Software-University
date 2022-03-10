// import { render, html } from 'lit-html';
import { render, html } from "./node_modules/lit-html/lit-html.js";
import movieListTemplate from './src/templates/movieListTemplate.js';
import movieService from './src/services/movieService.js';

let rootElement = document.querySelector("#root");

movieService.getAll()
    .then(movies => {
        movies[0].onDetailsClick = onDetailsClickHandler;

        let movieListTemplateResult = movieListTemplate(movies);

        render(movieListTemplateResult, rootElement);
    });

function onDetailsClickHandler(e) {
    e.preventDefault();

    console.log('click');
}