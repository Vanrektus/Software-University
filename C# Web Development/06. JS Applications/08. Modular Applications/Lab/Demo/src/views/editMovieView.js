import { html } from '../lib.js';
import * as services from '../services/movieService.js';

const editMovieTemplate = (onSubmit, movieData) => html `
  <div class="add-movie-container"> 
        <h3>Edit Movie Page</h3>

        <form @submit="${onSubmit}">
            <div class="mb-3 row">
                <label for="title" class="col-sm-2 col-form-label">Title:</label>
                <div class="col-sm-10">
                    <input type="text" class="form-control" id="title" name="title" value="${movieData.title}">
                </div>
            </div>
            <div class="mb-3 row">
                <label for="description" class="col-sm-2 col-form-label">Description:</label>
                <div class="col-sm-10">
                    <input type="text" class="form-control" id="description" name="description" value="${movieData.description}">
                </div>
            </div>
            <div class="mb-3 row">
                <label for="image" class="col-sm-2 col-form-label">Image:</label>
                <div class="col-sm-10">
                    <input type="text" class="form-control" id="image" name="image" value="${movieData.img}">
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

export function editMoviePage(context) {
    const movieId = context.params.movieId;

    services.getOne(movieId)
        .then(movieData => {
            let editMovieTemplateResult = editMovieTemplate(onSubmit, movieData);

            context.render(editMovieTemplateResult);
        });

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

        services.editMovie(movieId, movieInfo)
            .then(() => {
                alert(`Successfully edited movie!`);
                context.page.redirect('/movies');
            });
    }
}