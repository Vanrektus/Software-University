function solve() {
    let hireButtonElement = document.querySelector('#add-worker');

    hireButtonElement.addEventListener('click', (e) => {
        e.preventDefault();

        let fNameInputElement = document.querySelector('#fname');
        let lNameInputElement = document.querySelector('#lname');
        let emailInputElement = document.querySelector('#email');
        let birthInputElement = document.querySelector('#birth');
        let positionInputElement = document.querySelector('#position');
        let salaryInputElement = document.querySelector('#salary');

        let fNameCopy = fNameInputElement.value;
        let lNameCopy = lNameInputElement.value;
        let emailCopy = emailInputElement.value;
        let birthCopy = birthInputElement.value;
        let positionCopy = positionInputElement.value;
        let salaryCopy = salaryInputElement.value;

        if (fNameInputElement.value &&
            lNameInputElement.value &&
            emailInputElement.value &&
            birthInputElement.value &&
            positionInputElement.value &&
            salaryInputElement.value) {
            // Create elements
            let trElement = document.createElement('tr');

            // TD elements
            let tdFNameElement = document.createElement('td');
            tdFNameElement.textContent = fNameInputElement.value;
            let tdLNameElement = document.createElement('td');
            tdLNameElement.textContent = lNameInputElement.value;
            let tdEmailElement = document.createElement('td');
            tdEmailElement.textContent = emailInputElement.value;
            let tdBirthElement = document.createElement('td');
            tdBirthElement.textContent = birthInputElement.value;
            let tdPositionElement = document.createElement('td');
            tdPositionElement.textContent = positionInputElement.value;
            let tdSalaryElement = document.createElement('td');
            tdSalaryElement.textContent = salaryInputElement.value;

            // Buttons elements
            let tdButtonsElement = document.createElement('td');

            let firedButtonElement = document.createElement('button');
            firedButtonElement.setAttribute('class', 'fired');
            firedButtonElement.textContent = 'Fired';
            firedButtonElement.addEventListener('click', firedFunction);

            let editButtonElement = document.createElement('button');
            editButtonElement.setAttribute('class', 'edit');
            editButtonElement.textContent = 'Edit';
            editButtonElement.addEventListener('click', editFunction);

            // Append elements
            let tbodyElement = document.querySelector('#tbody');

            tdButtonsElement.appendChild(firedButtonElement);
            tdButtonsElement.appendChild(editButtonElement);

            trElement.appendChild(tdFNameElement);
            trElement.appendChild(tdLNameElement);
            trElement.appendChild(tdEmailElement);
            trElement.appendChild(tdBirthElement);
            trElement.appendChild(tdPositionElement);
            trElement.appendChild(tdSalaryElement);
            trElement.appendChild(tdButtonsElement);

            tbodyElement.appendChild(trElement);

            fNameInputElement.value = '';
            lNameInputElement.value = '';
            emailInputElement.value = '';
            birthInputElement.value = '';
            positionInputElement.value = '';
            salaryInputElement.value = '';

            let budgetSumElement = document.querySelector('#sum');
            budgetSumElement.textContent = (Number(budgetSumElement.textContent) + Number(tdSalaryElement.textContent)).toFixed(2);

            function firedFunction(e) {
                e.preventDefault();

                budgetSumElement.textContent = (Number(budgetSumElement.textContent) - Number(salaryCopy)).toFixed(2);

                trElement.remove();
            }

            function editFunction(e) {
                e.preventDefault();

                fNameInputElement.value = fNameCopy;
                lNameInputElement.value = lNameCopy;
                emailInputElement.value = emailCopy;
                birthInputElement.value = birthCopy;
                positionInputElement.value = positionCopy;
                salaryInputElement.value = salaryCopy;

                budgetSumElement.textContent = (Number(budgetSumElement.textContent) - Number(salaryInputElement.value)).toFixed(2);

                trElement.remove();
            }
        }
    })
}
solve()