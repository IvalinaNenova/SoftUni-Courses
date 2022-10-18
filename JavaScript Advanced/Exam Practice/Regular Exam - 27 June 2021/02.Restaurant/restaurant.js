class Restaurant {
    constructor(budget) {
        this.budgetMoney = budget;
        this.menu = {};
        this.stockProducts = {};
        this.history = [];
    }

    loadProducts(products) {
        //"{productName} {productQuantity} {productTotalPrice}"

        for (let product of products) {
            let [productName, productQuantity, productTotalPrice] = product.split(' ');
            let existingProduct = this.stockProducts[productName];

            if (Number(productTotalPrice) <= this.budgetMoney) {
                if (!existingProduct) {
                    this.stockProducts[productName] = 0;
                } 
                this.stockProducts[productName] += Number(productQuantity);
                this.budgetMoney -= Number(productTotalPrice);
                this.history.push(`Successfully loaded ${productQuantity} ${productName}`);

            } else {
                this.history.push(`There was not enough money to load ${productQuantity} ${productName}`);
            }
        }
        return this.history.join('\n');
    }
    addToMenu(meal, neededProducts, price) {
        let existingMeal = this.menu[meal];
        if (!existingMeal) {
            this.menu[meal] = { products: neededProducts, price };
        } else {
            return `The ${meal} is already in the our menu, try something different.`;
        }
        if (Object.keys(this.menu).length == 1) {
            return `Great idea! Now with the ${meal} we have 1 meal in the menu, other ideas?`;
        } else {
            return `Great idea! Now with the ${meal} we have ${Object.keys(this.menu).length} meals in the menu, other ideas?`;
        }
    }
    showTheMenu(){
        let output = [];
        if (Object.keys(this.menu).length == 0) {
            return 'Our menu is not ready yet, please come later...';
        }
        for (const [meal, value] of Object.entries(this.menu)) {
            output.push(`${meal} - $ ${value.price}`);
        }

        return output.join('\n');
    }
    makeTheOrder(meal){
        let requestedMeal = this.menu[meal];
        let isAvailable = true;
        if (!requestedMeal) {
            return `There is not ${meal} yet in our menu, do you want to order something else?`;
        }
        let productsNeeded = requestedMeal.products;
        for (const product of productsNeeded) {
            let[name, quantity] = product.split(' ');
            if (!this.stockProducts[name] || this.stockProducts[name] < Number(quantity)) {
                isAvailable = false;
                break;
            }
        }
        if (!isAvailable) {
            return `For the time being, we cannot complete your order (${meal}), we are very sorry...`;
        }else{
            for (const product of productsNeeded) {
                let[name, quantity] = product.split(' ');
                this.stockProducts[name] -= Number(quantity);
            }
            this.budgetMoney += requestedMeal.price;
            return `Your order (${meal}) will be completed in the next 30 minutes and will cost you ${requestedMeal.price}.`
        }
    }
}

let kitchen = new Restaurant(1000);
kitchen.loadProducts(['Yogurt 30 3', 'Honey 50 4', 'Strawberries 20 10', 'Banana 5 1']);
kitchen.addToMenu('frozenYogurt', ['Yogurt 1', 'Honey 1', 'Banana 1', 'Strawberries 10'], 9.99);
console.log(kitchen.makeTheOrder('frozenYogurt'));
