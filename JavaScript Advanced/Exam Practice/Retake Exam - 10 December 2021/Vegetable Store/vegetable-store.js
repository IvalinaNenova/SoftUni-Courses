class VegetableStore {
    constructor(owner, location) {
        this.owner = owner;
        this.location = location;
        this.availableProducts = [];
    }

    loadingVegetables(vegetables) {
        let uniqueVeggies = new Set();

        for (const veggie of vegetables) {
            let [type, quantity, price] = veggie.split(' ');
            quantity = Number(quantity);
            price = Number(price);

            let existingVeggie = this.availableProducts.find(v => v.type === type);
            if (existingVeggie) {

                if (price > existingVeggie.price) {
                    existingVeggie.price = price;
                };

                existingVeggie.quantity += quantity;

            } else {
                this.availableProducts.push({ type, quantity, price });
            }
            uniqueVeggies.add(type);
        }
        return `Successfully added ${Array.from(uniqueVeggies).join(', ')}`;
    }

    buyingVegetables(selectedProducts) {
        let totalPrice = 0;

        for (let order of selectedProducts) {
            let [type, quantity] = order.split(' ');
            quantity = Number(quantity);

            let existingVeggie = this.availableProducts.find(v => v.type === type);

            if (!existingVeggie) {
                throw new Error(`${type} is not available in the store, your current bill is $${totalPrice.toFixed(2)}.`);
            }

            if (quantity > existingVeggie.quantity || existingVeggie.quantity == 0) {
                throw new Error(`The quantity ${quantity} for the vegetable ${type} is not available in the store, your current bill is $${totalPrice.toFixed(2)}.`)
            }

            totalPrice += existingVeggie.price * quantity;
            existingVeggie.quantity -= quantity;
        }

        return `Great choice! You must pay the following amount $${totalPrice.toFixed(2)}.`
    }
    rottingVegetable(type, quantity) {
        let existingVeggie = this.availableProducts.find(v => v.type === type);

        if (!existingVeggie) {
            throw new Error(`${type} is not available in the store.`);
        }
        if (quantity >= existingVeggie.quantity) {
            existingVeggie.quantity = 0;
            return `The entire quantity of the ${type} has been removed.`;
        }
        existingVeggie.quantity -= quantity;
        return `Some quantity of the ${type} has been removed.`;
    }

    revision() {
        let output = ["Available vegetables:"];
        this.availableProducts.sort((a, b) => a.price - b.price)
            .map(v => output.push(`${v.type}-${v.quantity}-$${v.price}`));
        output.push(`The owner of the store is ${this.owner}, and the location is ${this.location}.`);

        return output.join('\n');
    }
}

// let vegStore = new VegetableStore("Jerrie Munro", "1463 Pette Kyosheta, Sofia");
// console.log(vegStore.loadingVegetables(["Okra 2.5 3.5", "Beans 10 2.8", "Celery 5.5 2.2", "Celery 0.5 2.5"]));
// console.log(vegStore.rottingVegetable("Okra", 1));
// console.log(vegStore.rottingVegetable("Okra", 2.5));
// console.log(vegStore.buyingVegetables(["Beans 8", "Celery 1.5"]));
// console.log(vegStore.revision());

// let vegStore = new VegetableStore("Jerrie Munro", "1463 Pette Kyosheta, Sofia");
// console.log(vegStore.loadingVegetables(["Okra 2.5 3.5", "Beans 10 2.8", "Celery 5.5 2.2", "Celery 0.5 2.5"]));
// console.log(vegStore.rottingVegetable("Okra", 1));
// console.log(vegStore.rottingVegetable("Okra", 2.5));
// console.log(vegStore.buyingVegetables(["Beans 8", "Okra 1.5"]));

// let vegStore = new VegetableStore("Jerrie Munro", "1463 Pette Kyosheta, Sofia");
// console.log(vegStore.loadingVegetables(["Okra 2.5 3.5", "Beans 10 2.8", "Celery 5.5 2.2", "Celery 0.5 2.5"]));
// console.log(vegStore.buyingVegetables(["Okra 1"]));
// console.log(vegStore.buyingVegetables(["Beans 8", "Okra 1.5"]));
// console.log(vegStore.buyingVegetables(["Banana 1", "Beans 2"]));

// let vegStore = new VegetableStore("Jerrie Munro", "1463 Pette Kyosheta, Sofia");
// console.log(vegStore.loadingVegetables(["Okra 2.5 3.5", "Beans 10 2.8", "Celery 5.5 2.2", "Celery 0.5 2.5"]));
