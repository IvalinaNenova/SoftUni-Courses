const person = {
    firstName: 'Pesho',
    lastName: 'Georgiev',
    introduce() {
        const getFullname = () => {
            return this.firstName + ' ' + this.lastName;
        }

        console.log(`Hello, my name is ${getFullname()}`)
    }
};

person.introduce();