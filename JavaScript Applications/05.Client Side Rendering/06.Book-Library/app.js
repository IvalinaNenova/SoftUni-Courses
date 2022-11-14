import { html, render } from './node_modules/lit-html/lit-html.js';
import { get, post, put, del } from './api.js';
import { initialTemplate } from './views/initial.js';
import { createTableRows } from './views/table.js';
const root = document.querySelector('body');

function onLoad() {
    render(initialTemplate, root)
}

onLoad()
document.querySelector('#loadBooks').addEventListener('click', loadBooks);
const body = document.querySelector('tbody');

async function loadBooks() {
    render(await createTableRows(), body);

    body.querySelectorAll('button:nth-of-type(2)').forEach(b => b.addEventListener('click', onDelete));
    body.querySelectorAll('button:nth-of-type(1)').forEach(b => b.addEventListener('click', onEdit));
}

const addForm = document.querySelector('#add-form');
addForm.addEventListener('submit', onAdd);

async function onAdd(e) {
    e.preventDefault();

    let formData = new FormData(addForm);
    let title = formData.get('title');
    let author = formData.get('author');

    if (title == '' || author == '') return;
    
    let response = await post({ title, author });

    if (response.status == 200) {
        loadBooks();
    }

    addForm.reset();
}

const editForm = document.querySelector('#edit-form');
editForm.addEventListener('submit', onSave);

async function onSave(e) {
    e.preventDefault();

    let formData = new FormData(editForm);

    let id = formData.get('id');
    let title = formData.get('title');
    let author = formData.get('author');

    if (title == '' || author == '') return;

    let response = await put(id, { title, author });

    if (response.status == 200) {
        loadBooks();
    }

    editForm.reset();
}
async function onDelete(e) {
    let response = await del(e.target.id);
    loadBooks();
}

function onEdit(e) {
    addForm.style.display = 'none';
    editForm.style.display = 'block';

    let author = e.target.parentNode.parentNode.children[1].textContent;
    let title = e.target.parentNode.parentNode.children[0].textContent;
    let [idInput, titleInput, authorInput] = editForm.querySelectorAll('input');

    idInput.value = e.target.id;
    titleInput.value = title;
    authorInput.value = author;
}