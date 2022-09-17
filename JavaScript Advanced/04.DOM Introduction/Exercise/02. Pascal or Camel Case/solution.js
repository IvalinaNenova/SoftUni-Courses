function solve() {
  let result = '';

  let toCamelCase = (input) => {
    result = input
    .toLowerCase()
    .split(' ')
    .map((word, index) => index === 0 ? word : word[0].toUpperCase() + word.substring(1, word.length))
    .join('');
  }

  let toPascalCase = (input) => {
    result = input
    .toLowerCase()
    .split(' ')
    .map((word) =>  word[0].toUpperCase() + word.substring(1, word.length))
    .join('');
    return result;
  }

  let input = document.getElementById('text').value;
  let namingConvention = document.getElementById('naming-convention').value;


  switch (namingConvention) {
    case 'Camel Case': toCamelCase(input);
      break;
      case 'Pascal Case': toPascalCase(input);
      break;
      default: result = 'Error!';

  }

  let resultElement = document.getElementById('result');
  resultElement.textContent = result;
}