import { html } from '../lib.js';

const guestUserTemplate = () => html `
    <!-- Guest users -->
    <div class="guest">
        <div class="profile">
            <a href="/login">Login</a>
            <a href="/register">Register</a>
        </div>
        <a class="active" href="/">Home Page</a>
    </div>
`;

const loggedUserTemplate = (email) => html `
    <!-- Logged users -->
    <div class="user">
        <a href="/create">Create Meme</a>
        <div class="profile">
            <span>Welcome, ${email}</span>
            <a href="/my-profile">My Profile</a>
            <a href="/logout">Logout</a>
        </div>
    </div>
`;

const navigationTemplate = (isAuthenticated, email) => html `
    <!-- Navigation -->
    <nav>
        <a href="/all-memes">All Memes</a>
        ${isAuthenticated ? loggedUserTemplate(email): guestUserTemplate()}
    </nav>
`;

export function renderNavigation(context) {
    return navigationTemplate(context.isAuthenticated, context.email);
}