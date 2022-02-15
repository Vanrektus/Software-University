window.addEventListener('load', solve);

function solve() {
    let totalLikesElement = document.querySelector('.likes p');
    let totalLikes = 0;
    let addButtonElement = document.querySelector('#add-btn');

    addButtonElement.addEventListener('click', (e) => {
        e.preventDefault();

        let addSongDivElement = document.querySelectorAll('.container-text form input');
        let genreElement = addSongDivElement[0];
        let nameElement = addSongDivElement[1];
        let authorElement = addSongDivElement[2];
        let dateElement = addSongDivElement[3];

        // empty ???
        if (genreElement.value &&
            nameElement.value &&
            authorElement.value &&
            dateElement.value) {

            // Create elements
            let divElement = document.createElement('div');
            divElement.setAttribute('class', 'hits-info');

            let imgElement = document.createElement('img');
            imgElement.setAttribute('src', './static/img/img.png');

            // H2 elements
            let h2GenreElement = document.createElement('h2');
            h2GenreElement.textContent = `Genre: ${genreElement.value}`;
            let h2NameElement = document.createElement('h2');
            h2NameElement.textContent = `Name: ${nameElement.value}`;
            let h2AuthorElement = document.createElement('h2');
            h2AuthorElement.textContent = `Author: ${authorElement.value}`;
            let h3DateElement = document.createElement('h3');
            h3DateElement.textContent = `Date: ${dateElement.value}`;

            // Button elements
            let saveButtonElement = document.createElement('button');
            saveButtonElement.setAttribute('class', 'save-btn');
            saveButtonElement.textContent = 'Save song';
            saveButtonElement.addEventListener('click', saveButtonFunction);

            let likeButtonElement = document.createElement('button');
            likeButtonElement.setAttribute('class', 'like-btn');
            likeButtonElement.textContent = 'Like song';
            likeButtonElement.addEventListener('click', likeButtonFunction);

            let deleteButtonElement = document.createElement('button');
            deleteButtonElement.setAttribute('class', 'delete-btn');
            deleteButtonElement.textContent = 'Delete';
            deleteButtonElement.addEventListener('click', deleteButtonFunction);

            // Append elements
            divElement.appendChild(imgElement);
            divElement.appendChild(h2GenreElement);
            divElement.appendChild(h2NameElement);
            divElement.appendChild(h2AuthorElement);
            divElement.appendChild(h3DateElement);
            divElement.appendChild(saveButtonElement);
            divElement.appendChild(likeButtonElement);
            divElement.appendChild(deleteButtonElement);

            document.querySelector('.all-hits-container').appendChild(divElement);

            genreElement.value = '';
            nameElement.value = '';
            authorElement.value = '';
            dateElement.value = '';
        }

        function saveButtonFunction(e) {
            e.preventDefault();

            // Create elements
            let divElement = document.createElement('div');
            divElement.setAttribute('class', 'hits-info');

            let imgElement = document.createElement('img');
            imgElement.setAttribute('src', './static/img/img.png');

            // H2 elements
            let h2GenreElement = document.createElement('h2');
            h2GenreElement.textContent = `${e.target.parentNode.children[1].textContent}`;
            let h2NameElement = document.createElement('h2');
            h2NameElement.textContent = `${e.target.parentNode.children[2].textContent}`;
            let h2AuthorElement = document.createElement('h2');
            h2AuthorElement.textContent = `${e.target.parentNode.children[3].textContent}`;
            let h3DateElement = document.createElement('h3');
            h3DateElement.textContent = `${e.target.parentNode.children[4].textContent}`;

            // Button elements
            let deleteButtonElement = document.createElement('button');
            deleteButtonElement.setAttribute('class', 'delete-btn');
            deleteButtonElement.textContent = 'Delete';
            deleteButtonElement.addEventListener('click', deleteButtonFunction);

            // Append elements
            divElement.appendChild(imgElement);
            divElement.appendChild(h2GenreElement);
            divElement.appendChild(h2NameElement);
            divElement.appendChild(h2AuthorElement);
            divElement.appendChild(h3DateElement);
            divElement.appendChild(deleteButtonElement);

            document.querySelector('.saved-container').appendChild(divElement);
            e.target.parentNode.remove();
        }

        function likeButtonFunction(e) {
            e.preventDefault();

            totalLikes++;
            totalLikesElement.textContent = `Total Likes: ${totalLikes}`;

            e.target.disabled = true;
        }

        function deleteButtonFunction(e) {
            e.preventDefault();

            e.target.parentNode.remove();
        }
    });
}