function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   let searchElement = document.getElementById('searchField');
   let rowsElement = document.querySelectorAll('tbody tr');

   function onClick() {
      for (let row of rowsElement) {
         row.classList.remove('select');
         if (row.textContent.includes(searchElement.value)) {
            row.className = 'select';
         }
      };

      searchElement.value = '';
   }
}