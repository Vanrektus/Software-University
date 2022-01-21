// Change background color
let siteWrapper = document.querySelector('body');
siteWrapper.style.backgroundColor = 'lightblue';

// Add hero to list
function addHero() {
    let heroNameInputElement = document.querySelector('#hero-name');
    let heroListElement = document.querySelector('#hero-list');

    // Add hero correctly by creating element (at last positon)
    let newHeroItemElement = document.createElement('li');
    newHeroItemElement.textContent = heroNameInputElement.value;
    heroListElement.appendChild(newHeroItemElement);

    // Add hero by clone element (also correct) (at first position)
    let firstListItemElement = heroListElement.children[0];
    let newClonedItemElement = firstListItemElement.cloneNode(true); // cloneNode(?true) can deep copy (copy the children of the parent) !!!
    newClonedItemElement.textContent = heroNameInputElement.value;
    heroListElement.prepend(newClonedItemElement); // Goes as first child !!!

    // Clear input
    heroNameInputElement.value = '';
}

// Delete last hero from list
function deleteLastHero() {
    let heroListElement = document.querySelector('#hero-list');
    let lastHeroElement = heroListElement.children[heroListElement.children.length - 1];

    // Delete from parent
    // heroListElement.removeChild(lastHeroElement); // Delete from parent

    // Delete the element directly
    lastHeroElement.remove();
}

// EVENT HANDLER !!!

// With HTML Attributes
function heroesMouseOverHandler(e) {
    console.log(e.target.textContent);
}

// Using DOM event handler - prefferd method
let heroNameInputElement = document.querySelector('#hero-name');

function heroNameINputHandler() {
    console.log(heroNameInputElement.value);
}

heroNameInputElement.addEventListener('input', heroNameINputHandler);

// Click on hero
let heroListElement = document.querySelector('#hero-list');

heroListElement.addEventListener('click', (e) => {
    if (e.target.tagName != 'LI') {
        console.log("Not here!");
        return;
    }

    console.log(`You clicked on hero: ${e.target.textContent}`);
});