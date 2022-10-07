function solve(arr) {
    let bottles = new Map();
    let juices = {};

    for (const input of arr) {
        let [juice, value] = input.split(' => ');
        let quantity = Number(value);
        if (!juices.hasOwnProperty(juice)) {
            juices[juice] = 0;
        }
        juices[juice] += quantity;

        let fullBottles = 0;
        let leftover = 0;

        if (juices[juice] >= 1000) {
            fullBottles = Math.floor(juices[juice] / 1000);
            leftover = juices[juice] % 1000;
            juices[juice] = leftover;

            if (!bottles.hasOwnProperty(juice)) {
                bottles[juice] = 0;
            }
            bottles[juice] += fullBottles;
        }
    }
    return Object.entries(bottles).map(x => x.join(' => ')).join('\n');
}

console.log(solve(['Kiwi => 234',
    'Pear => 2345',
    'Watermelon => 3456',
    'Kiwi => 4567',
    'Pear => 5678',
    'Watermelon => 6789']
));

let result = solve(['Orange => 2000',
    'Peach => 1432',
    'Banana => 450',
    'Peach => 600',
    'Strawberry => 549']
);
console.log(result);
