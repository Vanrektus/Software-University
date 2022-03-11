const url = "http://localhost:3030/jsonstore/collections/books";

export function getBooks() {
    return fetch(url)
        .then(res => res.json());
}