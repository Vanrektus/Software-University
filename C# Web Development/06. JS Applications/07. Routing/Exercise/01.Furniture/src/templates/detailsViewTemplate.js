import { logoutFunctionality } from '../api/accountApi.js';
import { deleteFunctionality } from '../api/furnitureApi.js';
import { html } from '../lib.js';

export default (furniture) => html `
    <header>
        <h1><a href="/">Furniture Store</a></h1>
        <nav>
            <a id="catalogLink" href="/" class="active">Dashboard</a>
            <div id="user">
                <a id="createLink" href="/create">Create Furniture</a>
                <a id="profileLink" href="/my-furniture">My Publications</a>
                <a @click="${logoutFunctionality}" id="logoutBtn" href="javascript:void(0)">Logout</a>
            </div>
            <div id="guest" class="hidden">
                <a id="loginLink" href="/login">Login</a>
                <a id="registerLink" href="/register">Register</a>
            </div>
        </nav>
    </header>
    <div class="container">
        <div class="row space-top">
            <div class="col-md-12">
                <h1>Furniture Details</h1>
            </div>
        </div>
        <div class="row space-top">
            <div class="col-md-4">
                <div class="card text-white bg-primary">
                    <div class="card-body">
                        <img src=".${furniture.img}" />
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <p>Make: <span>${furniture.make}</span></p>
                <p>Model: <span>${furniture.model}</span></p>
                <p>Year: <span>${furniture.year}</span></p>
                <p>Description: <span>${furniture.description}</span></p>
                <p>Price: <span>${furniture.price}</span></p>
                <p>Material: <span>${furniture.material}</span></p>
                <div>
                    <a href="/edit/${furniture._id}" class="btn btn-info hidden">Edit</a>
                    <a @click="${deleteFunctionality}" id="${furniture._id}" href=”#” class="btn btn-red hidden">Delete</a>
                </div>
            </div>
        </div>
    </div>
`;