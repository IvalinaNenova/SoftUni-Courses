class ChristmasDinner {
    constructor(budget) {
        if (budget < 0) {
            throw new Error('The budget cannot be a negative number');
        }
        this.budget = budget;
        this.dishes = [];
        this.products = [];
        this.guests = {};
    }
    shopping(product) {
        let type = product[0];
        let price = Number(product[1]);
        if (price > this.budget) {
            throw new Error("Not enough money to buy this product");
        }
        this.products.push(type);
        this.budget -= price;
        return `You have successfully bought ${type}!`
    }
    recipes(recipe) {
        let neededProducts = recipe.productsList;
        neededProducts.forEach(p => {
            if (!this.products.includes(p)) {
                throw new Error("We do not have this product");
            }
        });
        this.dishes.push(recipe);
        return (`${recipe.recipeName} has been successfully cooked!`);
    }
    inviteGuests(name, dish) {
        let existingDish = this.dishes.find(d => d.recipeName == dish);
        let existingGuest = this.guests[name];
        if (!existingDish) {
            throw new Error("We do not have this dish");
        }
        if (existingGuest) {
            throw new Error("This guest has already been invited");
        }
        this.guests[name] = existingDish;
        return `You have successfully invited ${name}!`;
    }
    showAttendance() {
        let output = [];
        Object.entries(this.guests).forEach(g => {
            output.push(`${g[0]} will eat ${g[1].recipeName}, which consists of ${g[1].productsList.join(', ')}`);
        })

        return output.join("\n");
    }
}
let dinner = new ChristmasDinner(300);

console.log(dinner.shopping(['Salt', 1]));
console.log(dinner.shopping(['Beans', 3]));
console.log(dinner.shopping(['Cabbage', 4]));
console.log(dinner.shopping(['Rice', 2]));
console.log(dinner.shopping(['Savory', 1]));
console.log(dinner.shopping(['Peppers', 1]));
console.log(dinner.shopping(['Fruits', 40]));
console.log(dinner.shopping(['Honey', 10]));

console.log(dinner.recipes({
    recipeName: 'Oshav',
    productsList: ['Fruits', 'Honey']
}));
console.log(dinner.recipes({
    recipeName: 'Folded cabbage leaves filled with rice',
    productsList: ['Cabbage', 'Rice', 'Salt', 'Savory']
}));
console.log(dinner.recipes({
    recipeName: 'Peppers filled with beans',
    productsList: ['Beans', 'Peppers', 'Salt']
}));

console.log(dinner.inviteGuests('Ivan', 'Oshav'));
console.log(dinner.inviteGuests('Petar', 'Folded cabbage leaves filled with rice'));
console.log(dinner.inviteGuests('Georgi', 'Peppers filled with beans'));

console.log(dinner.showAttendance());
