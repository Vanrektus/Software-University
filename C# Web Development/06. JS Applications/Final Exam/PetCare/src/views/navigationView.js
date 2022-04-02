import { html } from '../lib.js';

const guestUserTemplate = () => html `
    <!--Only Guest-->
    <li><a href="/login">Login</a></li>
    <li><a href="/register">Register</a></li>
`;

const loggedUserTemplate = () => html `
    <!--Only Users-->
    <li><a href="/create">Create Postcard</a></li>
    <li><a href="/logout">Logout</a></li>
`;

const navigationTemplate = (isAuthenticated) => html `
    <!-- Navigation -->
    <nav>
        <section class="logo">
            <img src="./images/logo.png" alt="logo">
        </section>
        <ul>
            <!--Users and Guest-->
            <li><a href="/">Home</a></li>
            <li><a href="/dashboard">Dashboard</a></li>
            ${isAuthenticated ? loggedUserTemplate() : guestUserTemplate()}
        </ul>
    </nav>
`;

export function renderNavigation(context) {
    return navigationTemplate(context.isAuthenticated);
}