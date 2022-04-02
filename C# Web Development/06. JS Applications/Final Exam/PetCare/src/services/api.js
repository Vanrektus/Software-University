export const baseUrl = `http://localhost:3030`;

export const registerUrl = `${baseUrl}/users/register`;
export const loginUrl = `${baseUrl}/users/login`;
export const logoutUrl = `${baseUrl}/users/logout`;

export const petsUrl = `${baseUrl}/data/pets`;
export const sortedPetsUrl = `${baseUrl}/data/pets?sortBy=_createdOn%20desc&distinct=name`;
export const petLikesUrl = `${baseUrl}/data/donation`;