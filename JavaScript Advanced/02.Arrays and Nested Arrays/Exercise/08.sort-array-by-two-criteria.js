function solve(array) {

    const result = array.sort((a, b) => {
        if (a.length == b.length) {
            return a.localeCompare(b);
        } else {
            return a.length - b.length;
        }
    });
    return result.join('\n');
}

console.log(solve(['alpha', 'beta', 'gamma']));
console.log(solve(['Isacc', 'Theodor', 'Jack', 'Harrison', 'George']));
console.log(solve(['test', 'Deny', 'omen', 'Default']));