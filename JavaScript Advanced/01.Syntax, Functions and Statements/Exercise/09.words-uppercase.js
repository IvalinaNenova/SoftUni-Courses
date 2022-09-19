function solve(text){

    let result = text.toUpperCase()
    .match(/\w+/g)
    .join(', ');

    console.log(result);
}

solve('Hi, how are you?');