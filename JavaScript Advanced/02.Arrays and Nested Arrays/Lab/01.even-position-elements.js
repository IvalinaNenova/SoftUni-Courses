function solve(input) {

    let elementsAtEvenIndex = [];

    // for (let i = 0; i < input.length; i++) {
    //     if (i % 2 == 0) {
    //         elementsAtEvenIndex.push(input[i]);
    //     }
    // }

    elementsAtEvenIndex = input.filter((x, i) => {
        if (i % 2 == 0) {
            return x;
        }
    })

    return elementsAtEvenIndex.join(' ');
}

console.log(solve(['20', '30', '40', '50', '60']));
console.log(solve(['5', '10']));