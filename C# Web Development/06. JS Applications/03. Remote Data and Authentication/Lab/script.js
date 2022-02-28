function functionality() {
    let baseUrl = `http://localhost:3030`;

    let movieForm = document.querySelector('#add-movie-form');
    movieForm.addEventListener('submit', submitFunctionality);
    let registerForm = document.querySelector('#register-form');
    registerForm.addEventListener('submit', registerFunctionality);
    let loginForm = document.querySelector('#login-form');
    loginForm.addEventListener('submit', loginFunctionality);

    let showAllMoviesButton = document.querySelector('#show-all-movies');
    showAllMoviesButton.addEventListener('click', showAllMoviesFunctionality);

    // TEST
    let checkInfoForm = document.querySelector('#check-info-form');
    checkInfoForm.addEventListener('submit', checkInfoFunctionality);
    // TEST

    function submitFunctionality(e) {
        e.preventDefault();

        let submitFormData = new FormData(e.currentTarget);

        let title = submitFormData.get('title');
        let description = submitFormData.get('description');
        let imageUrl = submitFormData.get('imageUrl');
        let token = getToken();

        fetch(`${baseUrl}/data/movies`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    'X-Authorization': token
                },
                body: JSON.stringify({
                    title,
                    description,
                    imageUrl
                })
            })
            .then(res => res.json())
            .then(data => {
                console.log(data);
            })
            .catch(err => {
                console.log(err);
            });

        e.currentTarget.reset();
    }

    function registerFunctionality(e) {
        e.preventDefault();

        let regForm = new FormData(e.currentTarget);
        let registerLoginSectionElement = document.querySelector('.register-login-section');
        let addMovieSectionElement = document.querySelector('.add-movie-section');

        fetch(`${baseUrl}/users/register`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    email: regForm.get('email'),
                    password: regForm.get('password')
                })
            })
            .then(res => res.json())
            .then(data => {
                saveToken(data.accessToken, data._id);
                console.log(data);

                registerLoginSectionElement.setAttribute('class', 'hide');
                addMovieSectionElement.removeAttribute('class', 'hide');
            })
            .catch(err => {
                console.log(err);
            });

        e.currentTarget.reset();
    }

    function loginFunctionality(e) {
        e.preventDefault();

        let loginForm = new FormData(e.currentTarget);
        let registerLoginSectionElement = document.querySelector('.register-login-section');
        let addMovieSectionElement = document.querySelector('.add-movie-section');
        let allMoviesSection = document.querySelector('.all-movies');

        fetch(`${baseUrl}/users/login`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    email: loginForm.get('email'),
                    password: loginForm.get('password')
                })
            })
            .then(res => res.json())
            .then(data => {
                saveToken(data.accessToken, data._id);
                console.log(data);

                registerLoginSectionElement.setAttribute('class', 'hide');
                addMovieSectionElement.removeAttribute('class', 'hide');
                allMoviesSection.removeAttribute('class', 'hide');
            })
            .catch(err => {
                console.log(err);
            });

        e.currentTarget.reset();
    }

    function showAllMoviesFunctionality() {
        let moviesListElement = document.querySelector('#movie-list');

        fetch(`${baseUrl}/data/movies`)
            .then(res => res.json())
            .then(movies => {
                console.log(movies);

                movies = movies.filter(movie => movie._ownerId === id);
                movies.forEach(movie => {
                    let movieElement = document.createElement('article');

                    let headerElement = document.createElement('h3');
                    headerElement.textContent = movie.title;

                    let contentElement = document.createElement('p');
                    contentElement.textContent = movie.description;

                    let imageElement = document.createElement('img');
                    imageElement.setAttribute('src', movie.imageUrl);

                    movieElement.appendChild(headerElement);
                    movieElement.appendChild(contentElement);
                    movieElement.appendChild(imageElement);

                    moviesListElement.appendChild(movieElement);
                })
            })
    }

    function saveToken(token, id) {
        localStorage.setItem('auth_token', token);
        localStorage.setItem('user_id', id);
    }

    function getToken() {
        let token = localStorage.getItem('auth_token');

        return token;
    }

    function getId() {
        let id = localStorage.getItem('user_id');

        return id;
    }

    // TEST
    function checkInfoFunctionality(e) {
        e.preventDefault();

        fetch('http://localhost:3030/users/me')
            .then(res => res.json())
            .then(data => {
                console.log(data);
            })
            .catch(err => {
                console.log(err);
            })
    }
    // TEST
}

functionality();