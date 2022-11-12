import {html, render } from './node_modules/lit-html/lit-html.js';

const root = document.querySelector('#root');
const form = document.querySelector('form');
form.addEventListener('submit', onSubmit);

function onSubmit(e){
    e.preventDefault();
    let towns = [...new FormData(form).values()][0].split(', ');

    let listTemplate = html`<ul>${towns.map(t => html`<li>${t}</li>`)}</ul>`;
    render(listTemplate, root);
}