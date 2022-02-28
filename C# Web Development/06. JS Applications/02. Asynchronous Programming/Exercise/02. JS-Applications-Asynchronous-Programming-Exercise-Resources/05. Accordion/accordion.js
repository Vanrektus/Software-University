function solution() {
    let baseUrl = `http://localhost:3030/jsonstore/advanced/articles/list`;

    fetch(baseUrl)
        .then(res => res.json())
        .then(articles => {
            Object.keys(articles).forEach(key => {
                let currArticle = articles[key];
                createHtmlArticle(currArticle);
            })
        });

    function createHtmlArticle(currArticle) {
        let currArticleUrl = `http://localhost:3030/jsonstore/advanced/articles/details/${currArticle._id}`;

        fetch(currArticleUrl)
            .then(res => res.json())
            .then(data => {
                let mainDivElement = document.createElement('div');
                mainDivElement.setAttribute('class', 'accordion');

                let headDivElement = document.createElement('div');
                headDivElement.setAttribute('class', 'head');

                let spanElement = document.createElement('span');
                spanElement.textContent = `${data.title}`;

                let showMoreButtonElement = document.createElement('button');
                showMoreButtonElement.setAttribute('class', 'button');
                showMoreButtonElement.setAttribute('id', `${data._id}`);
                showMoreButtonElement.textContent = `More`;
                showMoreButtonElement.addEventListener('click', showMoreFucntion);

                let extraDivElement = document.createElement('div');
                extraDivElement.setAttribute('class', 'extra');
                extraDivElement.style.display = 'none';

                let pElement = document.createElement('p');
                pElement.textContent = `${data.content}`;

                extraDivElement.appendChild(pElement);

                headDivElement.appendChild(spanElement);
                headDivElement.appendChild(showMoreButtonElement);

                mainDivElement.appendChild(headDivElement);
                mainDivElement.appendChild(extraDivElement);

                let mainSection = document.querySelector('#main');
                mainSection.appendChild(mainDivElement);
            });
    }

    function showMoreFucntion(e) {
        let showMoreButtonElement = e.target;
        let extraDivElement = e.target.parentNode.nextSibling;

        showMoreButtonElement.textContent = showMoreButtonElement.textContent === 'More' ? 'Less' : 'More';
        extraDivElement.style.display = extraDivElement.style.display === 'block' ? 'none' : 'block';
    }
}

solution();