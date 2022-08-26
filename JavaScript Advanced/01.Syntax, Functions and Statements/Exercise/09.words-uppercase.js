function solve(text){

    let result = text.toUpperCase()
    .match(/[A-Za-z]+/gm)
    .join(', ');

    console.log(result);
}

solve('Hi, how are you?');