function attachEvents() {
    let postsUrl = `http://localhost:3030/jsonstore/blog/posts`;
    let commentsUrl = `http://localhost:3030/jsonstore/blog/comments`;
    let postsSelectElement = document.querySelector('#posts');

    let loadButtonElement = document.querySelector('#btnLoadPosts');
    loadButtonElement.addEventListener('click', loadPosts);

    let viewButtonElement = document.querySelector('#btnViewPost');
    viewButtonElement.addEventListener('click', viewComments);

    function loadPosts() {
        fetch(postsUrl)
            .then(res => res.json())
            .then(posts => {
                Object.keys(posts).forEach(currPost => { createOptionHtml(posts, currPost); })
            })
            .catch();
    }

    function viewComments() {
        let selectedPostElement = document.querySelector('#posts');

        fetch(`${postsUrl}/${selectedPostElement.value}`)
            .then(res => res.json())
            .then(currPost => {
                let postTitleElement = document.querySelector('#post-title');
                postTitleElement.textContent = currPost.title;

                return fetch(commentsUrl)
                    .then(res => res.json())
                    .then((comments) => ({
                        id: currPost.id,
                        comments
                    }));
            })
            .then(({ id, comments }) => {
                let commentsElement = document.querySelector('#post-comments');
                Array.from(commentsElement.children).forEach(x => x.remove());

                let filteredComments = Object.values(comments).filter(x => x.postId === id);;
                filteredComments = filteredComments.forEach(x => {
                    let liElement = document.createElement('li');
                    liElement.setAttribute('id', x.id);
                    liElement.textContent = x.text;

                    commentsElement.appendChild(liElement);
                })
            })
            .catch();
    }

    function createOptionHtml(posts, currPost) {
        let optionElement = document.createElement('option');
        optionElement.setAttribute('value', `${posts[currPost].id}`);
        optionElement.textContent = posts[currPost].title;

        postsSelectElement.appendChild(optionElement);
    }
}

attachEvents();