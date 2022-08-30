function solve(array){

    // let sorted = array.sort((a,b) => a.localeCompare(b));

    // let i = 1;
    // for (const name of sorted) {
    //     console.log(`${i}.${name}`);
    //     i++;
    // }

    let result = array
    .sort((a,b) => a.localeCompare(b))
    .forEach((el, number) => console.log(`${number + 1}.${el}`));
}

solve(["John", "Bob", "Christina", "Ema"]);