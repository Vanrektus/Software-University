import { html } from '../lib.js';

const guestUserTemplate = () => html `
    <!-- Guest users -->
    <div id="guest">
        <a href="/login">Login</a>
        <a href="/register">Register</a>
    </div>
`;

const loggedUserTemplate = () => html `
    <!-- Logged-in users -->
    <div id="user">
        <a href="/create">Create Game</a>
        <a href="/logout">Logout</a>
    </div>
`;

const navigationTemplate = (isAuthenticated) => html `
    <!-- Navigation -->
    <h1><a class="home" href="/">GamesPlay</a></h1>
    <nav>
        <a href="/all-games">All games</a>
        ${isAuthenticated ? loggedUserTemplate() : guestUserTemplate()}
    </nav>
`;

export function renderNavigation(context) {
    return navigationTemplate(context.isAuthenticated);
}