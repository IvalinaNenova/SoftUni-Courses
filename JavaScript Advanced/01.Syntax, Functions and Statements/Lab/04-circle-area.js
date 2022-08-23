function solve(param) {
    let type = typeof (param);
    let result;
    if (type === 'number') {
        result = (Math.PI * Math.pow(param, 2).toFixed(2));
    } else {
        result = (`We can not calculate the circle area, because we receive a ${type}.`);
    }
    console.log(result);
}

solve(5);
solve('name');