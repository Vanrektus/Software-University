class Company {
    constructor() {
        this.departments = {};
    }

    addEmployee(name, salary, position, department) {
        if (isNullUndefinedOrWhitespace(name) ||
            isNullUndefinedOrWhitespace(salary) ||
            isNullUndefinedOrWhitespace(position) ||
            isNullUndefinedOrWhitespace(department) ||
            Number(salary) < 0) {

            throw new Error('Invalid input!');

        }

        if (!this.departments[department]) {
            this.departments[department] = {};
            this.departments[department].employees = [];
        }

        const currEmployee = {
            name,
            salary: Number(salary),
            position,
        };

        this.departments[department].employees.push(currEmployee);

        return `New employee is hired. Name: ${name}. Position: ${position}`;

        function isNullUndefinedOrWhitespace(input) {

            return !input || !input.toString().trim();

        }
    }

    bestDepartment() {
            let bestAvgSalaray = 0;
            let bestDepartment;
            let bestDepartmentName;

            for (const currDepartment in this.departments) {
                this.departments[currDepartment].avgSalary = (this.departments[currDepartment].employees.reduce((a, b) => a + b.salary, 0) / this.departments[currDepartment].employees.length) || 0;

                if (this.departments[currDepartment].avgSalary > bestAvgSalaray) {
                    bestAvgSalaray = this.departments[currDepartment].avgSalary;
                    bestDepartment = this.departments[currDepartment];
                    bestDepartmentName = currDepartment;
                }
            }

            bestDepartment.employees.sort((a, b) => b.salary - a.salary || a['name'].localeCompare(b['name']));

            return `Best Department is: ${bestDepartmentName}\nAverage salary: ${bestAvgSalaray.toFixed(2)}\n${bestDepartment.employees.map(x => `${x.name} ${x.salary} ${x.position}`).join('\n')}`;
    }
}

let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());