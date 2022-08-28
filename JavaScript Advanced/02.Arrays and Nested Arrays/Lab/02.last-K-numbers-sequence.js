function solve(n, k) {

    let finalArray = [1];

    for (let i = 1; i < n; i++) {
        
        let start = finalArray.length - k < 0 
        ? 0 
        : finalArray.length - k;

        let nextNUmber = finalArray.slice(start).reduce(((acc, num) => acc + num), 0);
        //let nextNUmber = sumLastK(lastKElements);
        finalArray.push(nextNUmber);
    }

    // function sumLastK(array) {

    //     let nextNum = array.reduce(((acc, num) => acc + num), 0);

    //     return Number(nextNum);
    // }

    return finalArray;
}

console.log(solve(6, 3));
console.log(solve(8, 2));