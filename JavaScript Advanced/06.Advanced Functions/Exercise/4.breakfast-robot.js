function solution() {
    let stock = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0
    }

    let recipes = {
        apple: { carbohydrate: 1, flavour: 2 },
        lemonade: { carbohydrate: 10, flavour: 20 },
        burger: { carbohydrate: 5, fat: 7, flavour: 3 },
        eggs: { protein: 5, fat: 1, flavour: 1 },
        turkey: { protein: 10, carbohydrate: 10, fat: 10, flavour: 10 },
    }

    let execute = {
        restock: (ingredient, quantity) => {
            stock[ingredient] += Number(quantity);
            return 'Success';
        },
        prepare: (option, quantity) => {
            let ingredientsNeeded = recipes[option];
            let isEnough = true;
            for (const ingredient in ingredientsNeeded) {
                if (stock[ingredient] < ingredientsNeeded[ingredient] * quantity) {
                    isEnough = false;
                    return `Error: not enough ${ingredient} in stock`;
                }
            }

            if (isEnough) {
                for (const ingredient in ingredientsNeeded) {
                    stock[ingredient] -= ingredientsNeeded[ingredient] * quantity;
                }
                return 'Success';
            }
        },
        report: () => {
            let result = [];
            for (let ingredient in stock) {
                result.push(`${ingredient}=${stock[ingredient]}`);
            }
            return result.join(' ');
        }
    };

    function foodManager(args) {
        let [command, option, quantity] = args.split(' ');
        return execute[command](option, quantity);

    }
    return foodManager;
}
let manager = solution();
console.log(manager("restock flavour 50")); // Success 
console.log(manager("prepare lemonade 4")); // Error: not enough carbohydrate in stock 
console.log(manager("restock carbohydrate 10")); // Success 
console.log(manager("restock flavour 10")); // Success 
console.log(manager("prepare apple 1")); // Success
console.log(manager("restock fat 10")); // Success
console.log(manager("prepare burger 1")); // Success
console.log(manager("report")); // protein=0 carbohydrate=4 fat=3 flavour=55
