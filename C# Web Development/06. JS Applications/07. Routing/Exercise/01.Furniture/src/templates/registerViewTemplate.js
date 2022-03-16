import { logoutFunctionality, registerFunctionality } from '../api/api.js';
import { html } from '../lib.js';

export default () => html `
    <header>
        <h1><a href="/">Furniture Store</a></h1>
        <nav>
            <a id="catalogLink" href="/" class="active">Dashboard</a>
            <div id="user" class="hidden">
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
    <div class="container">
        <div class="row space-top">
            <div class="col-md-12">
                <h1>Register New User</h1>
                <p>Please fill all fields.</p>
            </div>
        </div>
        <form id="register-form">
            <div class="row space-top">
                <div class="col-md-4">
                    <div class="form-group">
                        <label class="form-control-label" for="email">Email</label>
                        <input class="form-control" id="email" type="text" name="email">
                    </div>
                    <div class="form-group">
                        <label class="form-control-label" for="password">Password</label>
                        <input class="form-control" id="password" type="password" name="password">
                    </div>
                    <div class="form-group">
                        <label class="form-control-label" for="rePass">Repeat</label>
                        <input class="form-control" id="rePass" type="password" name="rePass">
                    </div>
                    <input @click="${registerFunctionality}" type="submit" class="btn btn-primary" value="Register" />
                </div>
            </div>
        </form>
    </div>
`;