function solve(arr) {
    let result = [];

    for (let data of arr) {
       let [name, level, items] = data.split(' / ');
       level = Number(level);
       items = items ? items.split(', ') : [];
       result.push({name, level, items});
    }

    return JSON.stringify(result);
}

console.log(solve(['Isacc / 25 / Apple, GravityGun',
'Derek / 12 / BarrelVest, DestructionSword',
'Hes / 1 / Desolator, Sentinel, Antara']
));