function Person(firstName, lastName) {
    const personObject = {
        firstName: firstName,
        lastName: lastName
    }
    Object.defineProperty(personObject, 'fullName', {
        get() { return this.firstName + ' ' + this.lastName; },
        set(value) {
            if (value.split(' ').length != 2) return;
            this.firstName = value.split(' ')[0];
            this.lastName = value.split(' ')[1];
        }
    });

    return personObject;
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

let person2 = new Person("Albert", "Simpson");
console.log(person2.fullName); //Albert Simpson
person2.firstName = "Simon";
console.log(person2.fullName); //Simon Simpson
person2.fullName = "Peter";
console.log(person2.firstName);  // Simon
console.log(person2.lastName);  // Simpson

