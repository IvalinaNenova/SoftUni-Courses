class Garden {
    constructor(spaceAvailable) {
        this.spaceAvailable = spaceAvailable;
        this.plants = [];
        this.storage = [];
    }

    addPlant(plantName, spaceRequired) {
        let plant = {
            plantName,
            spaceRequired,
            ripe: false,
            quantity: 0
        }
        if (this.spaceAvailable - plant.spaceRequired < 0) {
            throw new Error('Not enough space in the garden.');
        }
        this.plants.push(plant);
        this.spaceAvailable -= plant.spaceRequired;
        return `The ${plantName} has been successfully planted in the garden.`
    }

    ripenPlant(plantName, quantity) {
        let currentPlant = this.plants.find(plant => plant.plantName === plantName);
        if (!currentPlant) {
            throw new Error(`There is no ${plantName} in the garden.`);
        }
        if (currentPlant.ripe) {
            throw new Error(`The ${plantName} is already ripe.`);
        }
        if (quantity <= 0) {
            throw new Error(`The quantity cannot be zero or negative.`)
        }

        currentPlant.ripe = true;
        currentPlant.quantity += quantity;

        if (quantity == 1) {
            return `${quantity} ${plantName} has successfully ripened.`
        } else {
            return `${quantity} ${plantName}s have successfully ripened.`
        }
    }

    harvestPlant(plantName) {
        let currentPlant = this.plants.find(plant => plant.plantName === plantName);

        if (!currentPlant) {
            throw new Error(`There is no ${plantName} in the garden.`);
        }
        if (!currentPlant.ripe) {
            throw new Error(`The ${plantName} cannot be harvested before it is ripe.`);
        }
        this.plants = this.plants.filter(p => p.plantName !== currentPlant.plantName);
        this.spaceAvailable += currentPlant.spaceRequired;
        this.storage.push({
            plantName: currentPlant.plantName,
            quantity: currentPlant.quantity
        })
        return `The ${plantName} has been successfully harvested.`
    }

    generateReport() {
        let orderedPlants = this.plants.sort((a, b) => a.plantName - b.plantName).map(p => p.plantName);
        let output = [`The garden has ${this.spaceAvailable} free space left.`];

        output.push(`Plants in the garden: ${orderedPlants.join(', ')}`);
        
        if (this.storage.length == 0) {
            output.push(`Plants in storage: The storage is empty.`);
        } else {
            let formatedStorage = this.storage.map(p => `${p.plantName} (${p.quantity})`);
            output.push(`Plants in storage: ${formatedStorage.join(', ')}`);
        }

        return output.join('\n');
    }
}

// const myGarden = new Garden(250)
// console.log(myGarden.addPlant('apple', 20));
// console.log(myGarden.addPlant('orange', 200));
// console.log(myGarden.addPlant('olive', 50));

// const myGarden = new Garden(250)
// console.log(myGarden.addPlant('apple', 20));
// console.log(myGarden.addPlant('orange', 100));
// console.log(myGarden.addPlant('cucumber', 30));
// console.log(myGarden.ripenPlant('apple', 10));
// console.log(myGarden.ripenPlant('orange', 1));
// //console.log(myGarden.ripenPlant('orange', 4));

// const myGarden = new Garden(250)
// console.log(myGarden.addPlant('apple', 20));
// console.log(myGarden.addPlant('orange', 200));
// console.log(myGarden.addPlant('raspberry', 10));
// console.log(myGarden.ripenPlant('apple', 10));
// console.log(myGarden.ripenPlant('orange', 1));
// console.log(myGarden.harvestPlant('apple'));
// console.log(myGarden.harvestPlant('raspberry'));

const myGarden = new Garden(250)
console.log(myGarden.addPlant('apple', 20));
console.log(myGarden.addPlant('orange', 200));
console.log(myGarden.addPlant('raspberry', 10));
console.log(myGarden.ripenPlant('apple', 10));
console.log(myGarden.ripenPlant('orange', 1));
console.log(myGarden.harvestPlant('orange'));
console.log(myGarden.generateReport());

//console.log(myGarden.plants);
