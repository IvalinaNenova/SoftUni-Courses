function solve(num1, num2, operator) {
    let result;
    switch (operator) {
        case '+': result = num1 + num2;
            break;
        case '-': result = num1 - num2;
            break;
        case '*': result = num1 * num2;
            break;
        case '/': result = num1 / num2;
            break;
        case '%': result = num1 % num2;
            break;
        case '**': result = num1 ** num2;
            break;
    }

    console.log(result);
}

solve(5, 6, '+');
solve(5, 6, '-');
solve(5, 6, '*');
solve(10, 3, '/');
solve(6, 5, '%');
solve(5, 3, '**');