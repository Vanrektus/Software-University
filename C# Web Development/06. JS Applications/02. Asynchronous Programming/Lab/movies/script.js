let baseUrl = 'http://localhost:3000';
let movieListElement = document.querySelector('#movie-list');

let loadMoviesButtonElement = document.querySelector('#load-movies');
loadMoviesButtonElement.addEventListener('click', loadMoviesFunction);

let addMovieButtonElement = document.querySelector('#add-movie');
addMovieButtonElement.addEventListener('click', addMovieFunction);

function loadMoviesFunction(e) {
    e.preventDefault();

    fetch(`${baseUrl}/movies`)
        .then(response => response.json())
        .then(movies => {
            movies.forEach(movie => {
                let liElement = document.createElement('li');
                liElement.textContent = movie.title;

                movieListElement.appendChild(liElement);
            });
        })
        .catch(error => console.log(`rejected: ${error}`));
}

function addMovieFunction(e) {
    e.preventDefault();

    fetch(`${baseUrl}/movies`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                title: 'Man of Steel'
            })
        })
        .then(response => {
            console.log('sent');
        })
}