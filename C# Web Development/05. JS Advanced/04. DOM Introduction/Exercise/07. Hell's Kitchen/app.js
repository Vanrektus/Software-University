// 72/100 MINE!!!
function solve() {
    document.querySelector("#btnSend").addEventListener("click", onClick);

    function onClick() {

        let inputElement = JSON.parse(document.querySelector("textarea").value);
        let restaurants = [];

        for (const currRestaurant of inputElement) {

            let inputElementCopy = currRestaurant.split(" - ");
            let restaurantName = inputElementCopy[0];
            let restaurantWorkers = inputElementCopy[1].split(", ");
            const objRestaurant = {};

            if (!restaurants.some((x) => x.name === restaurantName)) {

                objRestaurant.name = restaurantName;
                objRestaurant.workers = new Array();

                restaurants.push(objRestaurant);

            } else {

                objRestaurant = restaurants.find((x) => x.name === restaurantName);

            }

            for (const currWorker of restaurantWorkers) {

                const objWorker = {};
                let currWorkerSplit = currWorker.split(" ");
                let currWorkerName = currWorkerSplit[0];
                let currWorkerSalary = Number(currWorkerSplit[1]);

                objWorker.name = currWorkerName;
                objWorker.salary = currWorkerSalary;

                objRestaurant.workers.push(objWorker);

            }

            let currAverageSalary = objRestaurant.workers.reduce((a, b) => a + b.salary, 0);

            objRestaurant.averageSalary = (currAverageSalary / objRestaurant.workers.length) || 0;
        }

        restaurants = restaurants.sort((a, b) => b.averageSalary - a.averageSalary);

        let bestRestaurant = restaurants[0];
        bestRestaurant.workers = bestRestaurant.workers.sort((a, b) => b.salary - a.salary);

        let bestSalary = bestRestaurant.workers[0].salary;

        let outputBestRestaurantElement = document.querySelector("#bestRestaurant p");
        outputBestRestaurantElement.textContent = `Name: ${bestRestaurant.name} Average Salary: ${bestRestaurant.averageSalary.toFixed(2)} Best Salary: ${bestSalary.toFixed(2)}`;

        let outputWorkersElement = document.querySelector("#workers p");

        for (const currWorker of bestRestaurant.workers) {

            outputWorkersElement.textContent += `Name: ${currWorker.name} With Salary: ${currWorker.salary} `;

        }
    }
}

// 100/100 BUT NOT MINE!!!
function solve() {
    document.querySelector('#btnSend').addEventListener('click', onClick);

    function onClick() {

        const restaurants = JSON.parse(document.getElementById('inputs').querySelector('textArea').value);
        let objRestaurants = [];
        let inputOrder = 0;

        for (let restaurant of restaurants) {

            const inputInfo = restaurant.split(' - ');
            let restName = inputInfo[0];
            const employeesInfo = inputInfo[1].split(', ');
            let objRestaurant = {};

            if (!objRestaurants.some(r => r.name === restName)) {

                objRestaurant.name = restName;
                objRestaurant.employees = new Array();
                objRestaurants.push(objRestaurant);

            } else {

                objRestaurant = objRestaurants.find(r => r.name === restName);

            }

            for (let employee of employeesInfo) {

                const objEmployee = {};
                let employeeInfo = employee.split(' ');
                let employeeName = employeeInfo[0];
                let employeeSalary = Number(employeeInfo[1]);
                objEmployee.name = employeeName;
                objEmployee.salary = employeeSalary;
                objRestaurant.employees.push(objEmployee);

            }

            let sumSalary = objRestaurant.employees.reduce((a, b) => a + b.salary, 0);
            objRestaurant.averageSalary = (sumSalary / objRestaurant.employees.length) || 0;

        }

        objRestaurants = objRestaurants.sort((a, b) => b.averageSalary - a.averageSalary);
        let bestRestaurant = objRestaurants[0];
        bestRestaurant.employees = bestRestaurant.employees.sort((a, b) => b.salary - a.salary);
        let bestRestSalary = bestRestaurant.employees[0].salary;
        let strRepresentBestRest = `Name: ${bestRestaurant.name} Average Salary: ${bestRestaurant.averageSalary.toFixed(2)} Best Salary: ${bestRestSalary.toFixed(2)}`;
        let workersBestRest = '';

        for (let worker of bestRestaurant.employees) {

            workersBestRest += `Name: ${worker.name} With Salary: ${worker.salary} `;

        }

        document.getElementById('bestRestaurant').querySelector('p').textContent = strRepresentBestRest;
        document.getElementById('workers').querySelector('p').textContent = workersBestRest;
    }
}