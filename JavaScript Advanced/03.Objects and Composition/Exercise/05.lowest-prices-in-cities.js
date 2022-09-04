function solve(arr) {
    let result = [];

    for (const line of arr) {
        let [town, product, price] = line.split(' | ');
        price = Number(price);

        let object = result.find(x => x.product === product);
        if (object) {

            if (price < object.price) {
                object.price = price;
                object.town = town;
            }
        }
        else {
            object = { product, price, town };
            result.push(object);
        }
    }

    for (let item of result) {
        console.log(`${item.product} -> ${item.price} (${item.town})`);
    }
}

solve(['Sample Town | Sample Product | 1000',
    'Sample Town | Orange | 2',
    'Sample Town | Peach | 1',
    'Sofia | Orange | 3',
    'Sofia | Peach | 2',
    'New York | Sample Product | 1000.1',
    'New York | Burger | 10']);
