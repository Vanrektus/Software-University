export const baseUrl = `http://localhost:3030`;

export const registerUrl = `${baseUrl}/users/register`;
export const loginUrl = `${baseUrl}/users/login`;
export const logoutUrl = `${baseUrl}/users/logout`;

export const gamesUrl = `${baseUrl}/data/games`;
export const sortedGamesUrl = `${baseUrl}/data/games?sortBy=_createdOn%20desc`;
export const sortedCategoryGamesUrl = `${baseUrl}/data/games?sortBy=_createdOn%20desc&distinct=category`;
export const gameCommentsUrl = `${baseUrl}/data/comments`;