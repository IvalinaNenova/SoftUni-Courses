import { html, render } from './node_modules/lit-html/lit-html.js';
import { get, post } from './api.js';
const select = document.getElementById('menu');

async function fillDropdown() {
    let result = await get();

    let template = html`
    ${result.map(option => html`<option .value=${option._id}>${option.text}</option>`)}
    `
    render(template, select);
}

fillDropdown();

document.querySelector('form').addEventListener('submit', addItem);

async function addItem(e) {
    e.preventDefault();
    let text = document.querySelector('#itemText').value;
    await post({ text });

    fillDropdown();
}