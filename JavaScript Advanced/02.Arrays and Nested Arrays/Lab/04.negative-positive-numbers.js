function solve(array){
    
    let result = [];
    
    for (const element of array) {
        if (element >= 0 ) {
            result.push(element);
        }else{
            result.unshift(element);
        }
    }

    result.forEach(x => console.log(x));
}

solve([7, -2, 8, 9]);
solve([3, -2, 0, -1]);