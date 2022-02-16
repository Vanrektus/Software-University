function solve() {
    // Input elements
    let inputTaskElement = document.querySelector('#task');
    let inputDescriptionElement = document.querySelector('#description');
    let inputDateElement = document.querySelector('#date');

    // Add button
    let addButtonElement = document.querySelector('#add');
    addButtonElement.addEventListener('click', addTask);

    // Sections elements
    let mainSectionsElements = document.querySelectorAll('section');

    function addTask(e) {
        e.preventDefault();

        if (inputTaskElement.value && inputDescriptionElement.value && inputDateElement.value) {
            // Open section
            let openSectionElement = mainSectionsElements[1].children[1];

            // Creating elements
            let articleElement = document.createElement('article');

            let h3Element = document.createElement('h3');
            h3Element.textContent = inputTaskElement.value;

            let pDescriptionElement = document.createElement('p');
            pDescriptionElement.textContent = `Description: ${inputDescriptionElement.value}`;
            let pDateElement = document.createElement('p');
            pDateElement.textContent = `Due Date: ${inputDateElement.value}`;

            let divElement = document.createElement('div');
            divElement.setAttribute('class', 'flex');

            let startButtonElement = document.createElement('button');
            startButtonElement.textContent = 'Start';
            startButtonElement.setAttribute('class', 'green');
            startButtonElement.addEventListener('click', startTask);

            let deleteButtonElement = document.createElement('button');
            deleteButtonElement.textContent = 'Delete';
            deleteButtonElement.setAttribute('class', 'red');
            deleteButtonElement.addEventListener('click', deleteTask);

            // Appending elements
            divElement.appendChild(startButtonElement);
            divElement.appendChild(deleteButtonElement);

            articleElement.appendChild(h3Element);
            articleElement.appendChild(pDescriptionElement);
            articleElement.appendChild(pDateElement);
            articleElement.appendChild(divElement);

            openSectionElement.appendChild(articleElement);

            inputTaskElement.value = '';
            inputDescriptionElement.value = '';
            inputDateElement.value = '';
        }

        function startTask(e) {
            // In progress section
            let inProgressSectionElement = mainSectionsElements[2].children[1];

            // Creating elements
            let articleElement = document.createElement('article');

            let h3Element = document.createElement('h3');
            h3Element.textContent = e.target.parentElement.parentElement.children[0].textContent;

            let pDescriptionElement = document.createElement('p');
            pDescriptionElement.textContent = e.target.parentElement.parentElement.children[1].textContent;
            let pDateElement = document.createElement('p');
            pDateElement.textContent = e.target.parentElement.parentElement.children[2].textContent;

            let divElement = document.createElement('div');
            divElement.setAttribute('class', 'flex');

            let deleteButtonElement = document.createElement('button');
            deleteButtonElement.textContent = 'Delete';
            deleteButtonElement.setAttribute('class', 'red');
            deleteButtonElement.addEventListener('click', deleteTask);

            let finishButtonElement = document.createElement('button');
            finishButtonElement.textContent = 'Finish';
            finishButtonElement.setAttribute('class', 'orange');
            finishButtonElement.addEventListener('click', finishTask);

            // Appending elements
            divElement.appendChild(deleteButtonElement);
            divElement.appendChild(finishButtonElement);

            articleElement.appendChild(h3Element);
            articleElement.appendChild(pDescriptionElement);
            articleElement.appendChild(pDateElement);
            articleElement.appendChild(divElement);

            inProgressSectionElement.appendChild(articleElement);

            // Deleting task from open section
            deleteTask(e);

            function finishTask(e) {
                // Complete section
                let completeSectionElement = mainSectionsElements[3].children[1];

                // Creating elements
                let articleElement = document.createElement('article');

                let h3Element = document.createElement('h3');
                h3Element.textContent = e.target.parentElement.parentElement.children[0].textContent;

                let pDescriptionElement = document.createElement('p');
                pDescriptionElement.textContent = e.target.parentElement.parentElement.children[1].textContent;
                let pDateElement = document.createElement('p');
                pDateElement.textContent = e.target.parentElement.parentElement.children[2].textContent;

                // Appending elements
                articleElement.appendChild(h3Element);
                articleElement.appendChild(pDescriptionElement);
                articleElement.appendChild(pDateElement);

                completeSectionElement.appendChild(articleElement);

                // Deleting task from in progress section
                deleteTask(e);
            }
        }

        function deleteTask(e) {
            e.target.parentElement.parentElement.remove();
        }
    };
}