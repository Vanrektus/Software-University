function loadRepos() {
    let usernameInputElement = document.querySelector('#username');
    let repostElement = document.querySelector('#repos');

    const url = `https://api.github.com/users/${usernameInputElement.value}/repos`;

    fetch(url)
        .then(response => response.json())
        .then(data => {
            Array.from(repostElement.children).forEach((x => x.remove()));

            data.forEach(x => {
                let currUrl = `https://github.com/${usernameInputElement.value}/${x.name}`;

                let liElement = document.createElement('li');

                let aElement = document.createElement('a');
                aElement.textContent = `${usernameInputElement.value}/${x.name}`;
                aElement.setAttribute('href', currUrl);

                liElement.appendChild(aElement);
                repostElement.appendChild(liElement);
            })
        })
        .catch(error => console.log(`rejected: ${error}`));
}