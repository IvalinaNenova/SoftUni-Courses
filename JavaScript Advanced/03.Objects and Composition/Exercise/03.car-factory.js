function solve(object) {

    const wheels = Array(4);
    object.wheelsize % 2 == 0
        ? wheels.fill(object.wheelsize - 1, 0, 4)
        : wheels.fill(object.wheelsize, 0, 4);


    function getEngine(power) {
        if (power > 120) {
            return { power: 200, volume: 3500 };
        } else if (power > 90) {
            return { power: 120, volume: 2400 };
        } else {
            return { power: 90, volume: 1800 }
        }
    }
    
    let finalProduct = {
        model: object.model,
        engine: getEngine(object.power),
        carriage: { type: object.carriage, color: object.color },
        wheels
    }

    return finalProduct;
}

console.log(solve({
    model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 14
}
));

console.log(solve({
    model: 'Opel Vectra',
    power: 110,
    color: 'grey',
    carriage: 'coupe',
    wheelsize: 17
}
));