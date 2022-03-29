import { html } from '../lib.js';

const guestUserTemplate = () => html `
    <!-- Guest users -->
    <div id="guest">
        <a href="/login">Login</a>
        <a href="/register">Register</a>
    </div>
`;

const loggedUserTemplate = (username) => html `
    <!-- Logged users -->
    <div id="profile">
        <a>Welcome ${username}</a>
        <a href="/my-listings">My Listings</a>
        <a href="/create">Create Listing</a>
        <a href="/logout">Logout</a>
    </div>
`;

const navigationTemplate = (isAuthenticated, username) => html `
    <!-- Navigation -->
    <header>
        <nav>
            <a class="active" href="/">Home</a>
            <a href="/listings">All Listings</a>
            <a href="/search">By Year</a>
            ${isAuthenticated ? loggedUserTemplate(username) : guestUserTemplate()}
        </nav>
    </header>
`;

export function renderNavigation(context) {
    return navigationTemplate(context.isAuthenticated, context.username);
}