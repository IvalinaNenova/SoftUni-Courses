function solve(commandsArray) {
    
    let num = 1;
    let result = [];

    for (const command of commandsArray) {

        if (command == 'add') {
            result.push(num);
        }else{
            result.pop();
        }

        num++;
    }

    return result.length == 0 ? 'Empty' : result.join('\n');
}

console.log(solve(['add', 
'add', 
'remove', 
'add', 
'add']
));

console.log(solve(['remove', 
'remove', 
'remove']
));