import { html } from '../lib.js';
import * as services from '../services/movieService.js';

const addMovieTemplate = (onSubmit, pageTitle) => html `
  <div class="add-movie-container"> 
        <h3>${pageTitle}</h3>

        <form @submit="${onSubmit}">
            <div class="mb-3 row">
                <label for="title" class="col-sm-2 col-form-label">Title:</label>
                <div class="col-sm-10">
                    <input type="text" class="form-control" id="title" name="title" placeholder="Title">
                </div>
            </div>
            <div class="mb-3 row">
                <label for="description" class="col-sm-2 col-form-label">Description:</label>
                <div class="col-sm-10">
                    <input type="text" class="form-control" id="description" name="description" placeholder="Description">
                </div>
            </div>
            <div class="mb-3 row">
                <label for="image" class="col-sm-2 col-form-label">Image:</label>
                <div class="col-sm-10">
                    <input type="text" class="form-control" id="image" name="image" placeholder="Image URL">
                </div>
            </div>
            <div class="mb-3 row">
                <div style="width: 200px;">
                    <input type="submit" class="btn btn-outline-primary">
                </div>
            </div>
        </form>
    </div>
`;

export function addMoviePage(context) {
    let addMovieTemplateResult = addMovieTemplate(onSubmit);

    context.render(addMovieTemplateResult);

    function onSubmit(e) {
        e.preventDefault();

        let formData = new FormData(e.currentTarget);

        let title = formData.get('title').trim();
        let description = formData.get('description').trim();
        let image = formData.get('image').trim();

        if (!(title && description && image)) {
            alert('All fields must be filled!');
            return;
        }

        let movieInfo = {
            title,
            description,
            img: image
        }

        services.addMovie(movieInfo)
            .then((data) => {
                alert(`Successfully added ${data.title} in the movie list!`);
                context.page.redirect('/movies');
            });
    }
}