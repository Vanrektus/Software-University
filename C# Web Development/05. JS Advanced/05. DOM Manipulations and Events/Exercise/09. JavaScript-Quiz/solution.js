function solve() {
    let mainElement = document.querySelector('#quizzie');
    let sectionsElements = document.querySelectorAll('section');

    // Adding id 'correct' to the correct answers
    let allAnswers = document.querySelectorAll('.answer-text');
    allAnswers[0].setAttribute('id', 'correct');
    allAnswers[3].setAttribute('id', 'correct');
    allAnswers[4].setAttribute('id', 'correct');

    let rightAnswers = 0;
    let currSectionIndex = 0;

    mainElement.addEventListener('click', (e) => {
        if (e.target && e.target.className === 'answer-text') {

            if (e.target.id === 'correct') {
                rightAnswers++;
            }

            if (currSectionIndex < 2) {

                sectionsElements[currSectionIndex].style.display = 'none';

                currSectionIndex++;

                sectionsElements[currSectionIndex].style.display = 'block';
            } else if (currSectionIndex >= 2) {

                let result = ``;

                sectionsElements[currSectionIndex].style.display = 'none';

                if (rightAnswers === 3) {
                    result = "You are recognized as top JavaScript fan!";
                } else {
                    result = `You have ${rightAnswers} right answers`;
                }

                document.querySelector('#results').children[0].children[0].textContent = result;
                document.querySelector('#results').style.display = 'block';
            }
        }
    });

}