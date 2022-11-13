import {html, render} from './node_modules/lit-html/lit-html.js';
import {towns} from './towns.js';
const townsDiv = document.querySelector('#towns');


let townsTemplate = html`
<ul>
   ${towns.map(town => html`<li>${town}</li>`)}
</ul>`

render(townsTemplate, townsDiv);

document.querySelector('button').addEventListener('click', search);
function search() {
   let input = document.getElementById('searchText').value;
   let listItems = Array.from(townsDiv.children[0].children);

   let count = 0
   listItems.forEach(li => {
      if (li.textContent.includes(input)) {
         li.setAttribute('class', 'active');
         count++;
      }else{
         li.removeAttribute('class', 'active');
      }
   })
   document.querySelector('#result').textContent = `${count} matches found`;
}
