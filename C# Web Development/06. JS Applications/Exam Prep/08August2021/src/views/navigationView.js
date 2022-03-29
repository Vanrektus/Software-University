import { html } from '../lib.js';

const guestUserTemplate = () => html `
    <!-- Guest users -->
    <div id="guest">
        <a class="button" href="/login">Login</a>
        <a class="button" href="/register">Register</a>
    </div>
`;

const loggedUserTemplate = (email) => html `
    <!-- Logged-in users -->
    <div id="user">
        <span>Welcome, ${email}</span>
        <a class="button" href="/my-books">My Books</a>
        <a class="button" href="/create">Add Book</a>
        <a class="button" href="/logout">Logout</a>
    </div>
`;

const navigationTemplate = (isAuthenticated, email) => html `
    <!-- Navigation -->
    <nav class="navbar">
        <section class="navbar-dashboard">
            <a href="/">Dashboard</a>
            ${isAuthenticated ? loggedUserTemplate(email) : guestUserTemplate()}
        </section>
    </nav>
`;

export function renderNavigation(context) {
    return navigationTemplate(context.isAuthenticated, context.email);
}