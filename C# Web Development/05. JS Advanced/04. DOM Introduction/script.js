// Change heading
let headingElement = document.getElementById("superhero-list-heading");
headingElement.textContent += " from MCU and DCU";

// Show inner HTML or text only
let superheroSectionElement = document.getElementById("superhero-section");
console.log(superheroSectionElement.innerHTML);
console.log(superheroSectionElement.textContent);

// Change background
let siteWrapper = document.getElementById("wrapper");
siteWrapper.style.backgroundColor = "lightblue";

// Get value from input
function addSuperhero() {
    let superheroNameInputElement = document.querySelector("#superhero-name");
    let superheroInputName = superheroNameInputElement.value;
    console.log(superheroInputName);

    // Add hero to list - hacker style not the right one ;)
    let anotherSuperheroListElement = document.querySelector("#superhero-list");
    anotherSuperheroListElement.innerHTML += `<li class="good">${superheroInputName}</li>`; // DANGEROUS!!! XSS ATTACKS!!!

    // Delete value when add button is clicked
    superheroNameInputElement.value = "";
}

// Targeting with css selector - returns NodeList
let allSuperheroesLiElements = document.querySelectorAll("#superhero-list li");
allSuperheroesLiElements.forEach((x) => {
    // DOESN'T WORK IN JUDGE!!!
    console.log(x.textContent);
});

// Targeting elemnts by class - returns HTMLCollection
let goodSuperheroesLiElements = document.getElementsByClassName("good");
goodSuperheroesLiElements[1].textContent += " - The Strongest Avenger";

for (const currHeroElement of goodSuperheroesLiElements) {
    // WORKS IN JUDGE!!!
    console.log(`good superhero: ${currHeroElement.textContent}`);
}

// Convert HTMLCollection and NodeList to JS Array
let goodSuperHeroes = Array.from(goodSuperheroesLiElements); // WORKS IN JUDGE!!!
let goodSuperHeroes2 = [...goodSuperheroesLiElements]; // DOESN'T WORK IN JUDGE!!!

//Get parent element and change background
let bodyElement = siteWrapper.parentElement;
bodyElement.style.backgroundColor = "lightblue";

// Get children of element
let superheroListElement = document.querySelector("#superhero-list");
let childrenElements = superheroListElement.children;
console.log(childrenElements);

// Use show/hide css logic
function toggleSuperheroes() {
    let toggleHeroesButtonElement = document.querySelector(
        "#toggle-superheroes"
    );

    if (superheroListElement.style.display == "none") {
        superheroListElement.style.display = "block";

        toggleHeroesButtonElement.textContent = "Hide Heroes";
    } else {
        superheroListElement.style.display = "none";

        toggleHeroesButtonElement.textContent = "Show Heroes";
    }
}

// Add striped style
let oddHeroes = document.querySelectorAll(
    "#superhero-section li:nth-of-type(2n)"
);

for (const currHero of oddHeroes) {
    currHero.style.backgroundColor = "lightgray";
}
