import { createFunctionality, isLoggedin, logoutFunctionality } from '../api/api.js';
import { html } from '../lib.js';
import productTemplate from './productTemplate.js';

export default (products) => html `
    <header>
        <h1><a href="/">Furniture Store</a></h1>
        <nav>
            <a id="catalogLink" href="/" class="active">Dashboard</a>
            <div id="user">
                <a id="createLink" href="/create">Create Furniture</a>
                <a id="profileLink" href="/my-furniture">My Publications</a>
                <a @click="${logoutFunctionality}" id="logoutBtn" href="javascript:void(0)">Logout</a>
            </div>
            <div id="guest">
                <a id="loginLink" href="/login">Login</a>
                <a id="registerLink" href="/register">Register</a>
            </div>
        </nav>
    </header>
    <div class="container"></div>
        <div class="row space-top">
            <div class="col-md-12">
                <h1>My Furniture</h1>
                <p>This is a list of your publications.</p>
            </div>
        </div>
        ${products.map(x => html`${productTemplate(x)}`)}
    </div>
`;