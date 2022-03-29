import * as authService from '../services/authService.js';

export function authMiddleware(context, next) {
    let userData = authService.getUserData();

    if (userData) {
        context.isAuthenticated = true;
        context.id = userData.id;
        context.username = userData.username;
        context.accessToken = userData.accessToken;
    }

    next();
}