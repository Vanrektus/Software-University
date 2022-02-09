function Person(firstName, lastName) {
    this.firstName = firstName;
    this.lastName = lastName;

    Object.defineProperty(this, 'fullName', {
        get: function() {
            return `${this.firstName} ${this.lastName}`;
        },
        set: function(fullName) {
            let pattern = /(?<firstName>\w+) (?<lastName>\w+)/;
            let matchResult = fullName.match(pattern);

            if (matchResult) {
                this.firstName = matchResult.groups.firstName;
                this.lastName = matchResult.groups.lastName;
            }
        },
    })
}

let person = new Person("Peter", "Ivanov");
console.log(person.fullName); //Peter Ivanov
person.firstName = "George";
console.log(person.fullName); //George Ivanov
person.lastName = "Peterson";
console.log(person.fullName); //George Peterson
person.fullName = "Nikola Tesla";
console.log(person.firstName); //Nikola
console.log(person.lastName); //Tesla

console.log('=======');

let person2 = new Person("Albert", "Simpson");
console.log(person2.fullName); //Albert Simpson
person2.firstName = "Simon";
console.log(person2.fullName); //Simon Simpson
person2.fullName = "Peter";
console.log(person2.firstName); // Simon
console.log(person2.lastName); // Simpson