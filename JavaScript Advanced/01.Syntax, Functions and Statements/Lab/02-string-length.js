function solve(first, second, third) {
    
    let sum = first.length + second.length + third.length;
    let average = Math.floor(sum / 3);

    console.log(sum);
    console.log(average);
}

solve('chocolate', 'ice cream', 'cake');