function solve(year, month, day) {

    let date = new Date(`${year}-${month}-${day}`);
    let previous = new Date(date.setDate(date.getDate() - 1));

    console.log(`${previous.getFullYear()}-${previous.getMonth() + 1}-${previous.getDate()}`);
}

solve(2016, 9, 30);
solve(2016, 10, 1);
solve(2016, 1, 1);