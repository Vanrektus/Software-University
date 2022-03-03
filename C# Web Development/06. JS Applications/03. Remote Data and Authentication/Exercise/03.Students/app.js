function solve() {

    let url = `http://localhost:3030/jsonstore/collections/students`;

    let tbodyElement = document.querySelector('tbody');
    let form = document.querySelector('#form');
    form.addEventListener('submit', submitFunctionality);

    function loadStudents() {
        fetch(url)
            .then(res => res.json())
            .then(students => {
                Array.from(tbodyElement.children).forEach(x => x.remove());

                Object.keys(students)
                    .forEach(curr => { createHrml(students, curr) });
            });
    };

    loadStudents();

    function submitFunctionality(e) {
        e.preventDefault();

        let submitForm = new FormData(e.currentTarget);
        let inputFName = submitForm.get('firstName');
        let inputLName = submitForm.get('lastName');
        let inputFacNum = submitForm.get('facultyNumber');
        let inputGrade = submitForm.get('grade');

        if (!(inputFName && inputLName && inputFacNum && inputGrade)) {
            return;
        }

        fetch(url, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    firstName: inputFName,
                    lastName: inputLName,
                    facultyNumber: inputFacNum,
                    grade: inputGrade
                })
            })
            .catch(err => { console.log(err); });

        loadStudents();
        e.currentTarget.reset();
    }

    function createHrml(students, curr) {
        let trElement = document.createElement('tr');

        let tdFNameElement = document.createElement('td');
        tdFNameElement.textContent = students[curr].firstName;

        let tdLNameElement = document.createElement('td');
        tdLNameElement.textContent = students[curr].lastName;

        let tdFacNum = document.createElement('td');
        tdFacNum.textContent = students[curr].facultyNumber;

        let tdGrade = document.createElement('td');
        tdGrade.textContent = students[curr].grade;

        trElement.appendChild(tdFNameElement);
        trElement.appendChild(tdLNameElement);
        trElement.appendChild(tdFacNum);
        trElement.appendChild(tdGrade);

        tbodyElement.appendChild(trElement);
    }
}

solve();