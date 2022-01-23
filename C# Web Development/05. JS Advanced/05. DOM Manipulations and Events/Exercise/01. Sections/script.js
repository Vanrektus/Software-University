function create(words) {
    let mainDivElement = document.querySelector('#content');

    for (let i = 0; i < words.length; i++) {
        let newDivElement = document.createElement('div');
        let newParagraphElement = document.createElement('p');

        newParagraphElement.textContent = words[i];
        newParagraphElement.style.display = 'none';

        newDivElement.appendChild(newParagraphElement);
        mainDivElement.appendChild(newDivElement);

    }

    mainDivElement.addEventListener('click', (e) => {
        if (e.target && e.target.tagName != 'P') {
            e.target.querySelector('p').style.display = 'block';
        }
    });
}