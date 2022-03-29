export const baseUrl = `http://localhost:3030`;

export const registerUrl = `${baseUrl}/users/register`;
export const loginUrl = `${baseUrl}/users/login`;
export const logoutUrl = `${baseUrl}/users/logout`;

export const booksUrl = `${baseUrl}/data/books`;
export const sortedBooksUrl = `${baseUrl}/data/books?sortBy=_createdOn%20desc`;
export const bookLikesUrl = `${baseUrl}/data/likes`;