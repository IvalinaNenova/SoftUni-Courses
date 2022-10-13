class CarDealership {
    constructor(name) {
        this.name = name;
        this.totalIncome = 0;
        this.soldCars = [];
        this.availableCars = [];
    }

    addCar(model, horsepower, price, mileage) {
        if (!model || horsepower < 0 || price < 0 || mileage < 0) {
            throw new Error("Invalid input!");
        }

        this.availableCars.push({
            model,
            horsepower,
            price,
            mileage
        })

        return `New car added: ${model} - ${horsepower} HP - ${mileage.toFixed(2)} km - ${price.toFixed(2)}$`;
    }

    sellCar(model, desiredMileage) {
        let searchedCar = this.availableCars.find(c => c.model === model);
        if (!searchedCar) {
            throw new Error(`${model} was not found!`);
        }
        let carsMileage = searchedCar.mileage;
        let soldPrice = 0;
        if (carsMileage <= desiredMileage) {
            soldPrice = searchedCar.price;
        } else if (carsMileage - desiredMileage <= 40000) {
            soldPrice = searchedCar.price * 0.95;
        } else {
            soldPrice = searchedCar.price * 0.9;
        }
        this.availableCars = this.availableCars.filter(c => c.model !== model);
        this.soldCars.push({
            model: searchedCar.model,
            horsepower: searchedCar.horsepower,
            soldPrice
        })
        this.totalIncome += soldPrice;
        return `${model} was sold for ${soldPrice.toFixed(2)}$`
    }

    currentCar (){
        if (this.availableCars.length === 0) {
            return 'There are no available cars';
        }
        let formatedCars = this.availableCars.map(c => `---${c.model} - ${c.horsepower} HP - ${c.mileage.toFixed(2)} km - ${c.price.toFixed(2)}$`);
        formatedCars.unshift('-Available cars:');

        return formatedCars.join('\n');
    }
    
    salesReport (criteria){
        if(criteria != 'model' && criteria != 'horsepower'){
            throw new Error('Invalid criteria!');
        }

        let sorted = criteria == 'model'
        ? this.soldCars.sort((a, b) => a.model.localeCompare(b.model))
        :this.soldCars.sort((a, b) => b.horsepower - a.horsepower);
        
        let output = [`-${this.name} has a total income of ${this.totalIncome.toFixed(2)}$`];
        output.push(`-${this.soldCars.length} cars sold:`);

        this.soldCars.map(car => output.push(`---${car.model} - ${car.horsepower} HP - ${car.soldPrice.toFixed(2)}$`));

        return output.join('\n');
    }
}

let dealership = new CarDealership('SoftAuto');
dealership.addCar('Toyota Corolla', 100, 3500, 190000);
dealership.addCar('Mercedes C63', 300, 29000, 187000);
dealership.addCar('Audi A3', 120, 4900, 240000);
dealership.sellCar('Toyota Corolla', 230000);
dealership.sellCar('Mercedes C63', 110000);
console.log(dealership.salesReport('horsepower'));




