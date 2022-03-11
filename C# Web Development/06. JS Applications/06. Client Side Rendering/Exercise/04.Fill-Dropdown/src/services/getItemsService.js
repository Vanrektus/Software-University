const url = "http://localhost:3030/jsonstore/advanced/dropdown";

export function getItems() {
    return fetch(url)
        .then(res => res.json());
}