function loadCommits() {
    let usernameInputElement = document.querySelector('#username');
    let repoInputElement = document.querySelector('#repo');
    let commitsElement = document.querySelector('#commits');

    const url = `https://api.github.com/repos/${usernameInputElement.value}/${repoInputElement.value}/commits`;
    const testUrl = `https://api.github.com/repos/Vanrektus/Software-University/commits`;

    fetch(url)
        .then(response => response.json())
        .then(data => {
            Array.from(commitsElement.children).forEach((x => x.remove()));

            data.forEach(x => {
                let liElement = document.createElement('li');
                liElement.textContent = `${x.commit.author.name}: ${x.commit.message}`;
                commitsElement.appendChild(liElement);
            })

        })
        .catch(error => {
            Array.from(commitsElement.children).forEach((x => x.remove()));

            let liElement = document.createElement('li');
            liElement.textContent = `Error: 404 (Not Found)`;
            commitsElement.appendChild(liElement);
        })
}