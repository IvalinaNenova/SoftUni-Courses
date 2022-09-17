function search() {
   let textToSearch = document.getElementById('searchText').value;
   let townsElements = Array.from(document.querySelectorAll('#towns li'));
   let resultElement = document.getElementById('result');

   let count = 0;

   for (const town of townsElements) {
      if (town.textContent.includes(textToSearch)) {
         count++;
         town.style.fontWeight = 'bold';
         town.style.textDecoration = 'underline';
      }else{
         town.style.fontWeight = 'normal';
         town.style.textDecoration = 'none';
      }
   }

   resultElement.textContent = `${count} matches found`;
}
