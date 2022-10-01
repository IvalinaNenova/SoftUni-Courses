function solve(...params) {
    let result = {};

    for (const item of params) {
        console.log(`${typeof(item)}: ${item}`);
        if (!result.hasOwnProperty(typeof(item))){
            result[typeof(item)] = 0;
        }
        result[typeof(item)] ++;
    }
    let sorted = Object.entries(result).sort((a, b) => b[1] - a[1]);
    for (const [type, count] of sorted) {
        console.log(`${type} = ${count}`);
    }
}
solve('cat', 42, function () { console.log('Hello world!'); }, 'dog', 56, 78)