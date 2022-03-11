const url = "http://localhost:3030/jsonstore/advanced/table";

export function getStudents() {
    return fetch(url)
        .then(res => res.json());
}