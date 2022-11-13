import { html, render } from './node_modules/lit-html/lit-html.js';
import { get } from './api.js';

async function solve() {
   let result = await get();

   const table = document.querySelector('tbody');
   let fragment = document.createDocumentFragment();
   fragment = html`
   ${result.map(entry => html`
   <tr>
      <td>${entry.firstName} ${entry.lastName}</td>
      <td>${entry.email}</td>
      <td>${entry.course}</td>
   </tr>
   `)}
   `;

   render(fragment, table)

   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      let input = document.querySelector('#searchField');
      let searchedText = input.value;

      Array.from(table.querySelectorAll('tr'))
         .forEach(row => {
            let rowInfo = Array.from(row.children).map(child => child.textContent).join(' ');

            rowInfo.toLowerCase().includes(searchedText.toLowerCase())
               ? row.setAttribute('class', 'select')
               : row.removeAttribute('class', 'select');
         });

      input.value = '';
   }
}

solve();