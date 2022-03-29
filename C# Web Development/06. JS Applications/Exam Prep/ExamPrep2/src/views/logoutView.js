import * as authService from '../services/authService.js';

export function logoutPage(context) {
    authService.logout()
        .finally(() => {
            context.page.redirect('/');
        })
}