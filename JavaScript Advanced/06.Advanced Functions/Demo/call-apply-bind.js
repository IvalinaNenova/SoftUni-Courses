// Call & Apply
function introduce(firstName, lastName) {
    console.log(`Hello ${firstName} ${lastName}, my name is ${this.name}`);
}

introduce('Gosho', 'Ivanov'); // Global invocation

let person = {
    name: 'Pesho'
}

introduce.call(person, 'Gosho', 'Ivanov'); // invoke using call
introduce.apply(person, ['Stamat', 'Stamatov']); // invoke using apply


// Bind
let superHuman = {
    name: 'Superman'
};

let superIntroduction = introduce.bind(superHuman,'Lois', 'Lane');
superIntroduction();

