function solve(array) {

    let info = {};
    for (let i = 0; i < array.length; i+=2) {
        let food = array[i];
        let calories = Number(array[i+1]);

        info[food] = calories;
    }

    return info;
}

console.log(solve(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']));
console.log(solve(['Potato', '93', 'Skyr', '63', 'Cucumber', '18', 'Milk', '42']));