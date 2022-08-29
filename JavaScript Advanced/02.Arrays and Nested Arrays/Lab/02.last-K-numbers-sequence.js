function solve(n, k) {

    let finalArray = [1];

    for (let i = 1; i < n; i++) {
        
        let start = i - k < 0 
        ? 0 
        : i - k;

        let nextNumber = finalArray.slice(start).reduce(((acc, num) => acc + num), 0);
        //let nextNUmber = sumLastK(lastKElements);
        finalArray.push(nextNumber);
    }

    // function sumLastK(array) {

    //     let nextNum = array.reduce(((acc, num) => acc + num), 0);

    //     return Number(nextNum);
    // }

    return finalArray;
}

console.log(solve(6, 3));
console.log(solve(8, 2));