import { html, render } from './node_modules/lit-html/lit-html.js';
import {cats} from './catSeeder.js';
let root = document.querySelector('#allCats');

const catTemplate = html`
<ul>${cats.map(c => html`
<li>
<img src="./images/${c.imageLocation}.jpg" width="250" height="250" alt="Card image cap">
<div class="info">
    <button @click=${onClickhandler} .id=${c.id} class="showBtn">Show status code</button>
    <div class="status" style="display: none" id="100">
        <h4>Status Code: ${c.statusCode}</h4>
        <p>${c.statusMessage}</p>
    </div>
</div>
</li>`)}
</ul>
`;

function onClickhandler(e){
    if (e.target.textContent == 'Show status code') {
        e.target.parentNode.children[1].style.display = 'block';
        e.target.textContent = 'Hide status code';
    }else{
        e.target.parentNode.children[1].style.display = 'none';
        e.target.textContent = 'Show status code';
    }
}

render(catTemplate, root);
