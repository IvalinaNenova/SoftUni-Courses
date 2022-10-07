function solve(input) {
    let cars = new Map();
    
    for (const line of input) {
        let [brand, model, value] = line.split(' | ');
        let carsProduced = Number(value);

        if (!cars.get(brand)) {
            cars.set(brand, new Map());
        }

        if (!cars.get(brand).get(model)) {
            cars.get(brand).set(model, 0);
        }

        let carsAlreadyProduced = Number(cars.get(brand).get(model));
        cars.get(brand).set(model, carsAlreadyProduced + carsProduced);
    }

    for (const [brand, data] of cars) {
        console.log(brand);
        data.forEach((quantity, model) => { console.log(`###${model} -> ${quantity}`); })
    }
}

solve(['Audi | Q7 | 1000',
    'Audi | Q6 | 100',
    'BMW | X5 | 1000',
    'BMW | X6 | 100',
    'Citroen | C4 | 123',
    'Volga | GAZ-24 | 1000000',
    'Lada | Niva | 1000000',
    'Lada | Jigula | 1000000',
    'Citroen | C4 | 22',
    'Citroen | C5 | 10']
);