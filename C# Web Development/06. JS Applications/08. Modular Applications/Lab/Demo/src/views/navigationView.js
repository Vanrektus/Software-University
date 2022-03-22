import { html } from '../lib.js';

const showUserInfoTemplate = (username) => html `
    <span class="welcome-user">Welcome, ${username}</span>
`;

const guestButtonsTemplate = () => html `
    <a class="btn btn-outline-dark" id="loginBtn" href="/login">Login</a>
    <a class="btn btn-outline-dark" id="registerBtn" href="/register">Register</a>
`;

const loggedUserBtnsTemplate = () => html `
    <a class="btn btn-outline-dark" href="/my-movies">My Movies</a>
    <a class="btn btn-outline-dark" id="logoutBtn" href="/logout">Logout</a>
    <a class="btn btn-outline-dark" href="/add-movie">Add Movie</a>
`;

const navigationTemplate = (isAuthenticated, username) => html `
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
        <div class="container-fluid">
            <a class="navbar-brand" href="/">MovieDB</a>
            <div class="collapse navbar-collapse" id="navbarNavAltMarkup">
                <div class="navbar-nav">
                    <a class="btn btn-outline-dark" aria-current="page" href="/">Home</a>
                    <a class="btn btn-outline-dark" href="/movies">Movies</a>
                    ${isAuthenticated ? loggedUserBtnsTemplate() : guestButtonsTemplate()}
                </div>
            </div>
            ${isAuthenticated && showUserInfoTemplate(username)}
        </div>
    </nav>
`;

export function renderNavigation(context) {
    return navigationTemplate(context.isAuthenticated, context.username);
}