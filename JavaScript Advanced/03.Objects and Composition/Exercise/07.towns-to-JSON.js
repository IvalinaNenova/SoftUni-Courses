function solve(arr) {
    let result = [];
    const properties = arr[0].split(/\s*\|\s*/mg).filter(e=> e.trim());

    for (let i = 1; i < arr.length; i++) {
        let data = arr[i].split(/\s*\|\s*/mg).filter(e=> e.trim());

        let name = data[0];
        let latitude = Number(data[1]).toFixed(2);
        let longtitude = Number(data[2]).toFixed(2);

        let town = {};
        town[properties[0]] = name;
        town[properties[1]] = Number(latitude);
        town[properties[2]] = Number(longtitude);

        result.push(town);
    }

    let jsonString = JSON.stringify(result);
    return jsonString;
}

console.log(solve(['| Town | Latitude | Longitude |',
'| Sofia | 42.696552 | 23.32601 |',
'| Beijing | 39.913818 | 116.363625 |']
));