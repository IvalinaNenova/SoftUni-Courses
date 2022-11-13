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
    console.log([...document.querySelectorAll('button:nth-of-type(1)')])
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

    let response = await post({ title, author });

    if (response.status == 200) {
        loadBooks();
    }
}

const editForm = document.querySelector('#edit-form');
editForm.addEventListener('submit', onSave);
async function onSave(e) {
    e.preventDefault();

    let formData = new FormData(editForm);
    let title = formData.get('title');
    let author = formData.get('author');

    let response = await put({ title, author });

    loadBooks();
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
    let [id, titleInput, authorInput] = editForm.querySelectorAll('input');
    titleInput.value = title;
    authorInput.value = author;
}



/*<button id="loadBooks">LOAD ALL BOOKS</button>
    <table>
        <thead>
            <tr>
                <th>Title</th>
                <th>Author</th>
                <th>Action</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>Harry Potter</td>
                <td>J. K. Rowling</td>
                <td>
                    <button>Edit</button>
                    <button>Delete</button>
                </td>
            </tr>
            <tr>
                <td>Game of Thrones</td>
                <td>George R. R. Martin</td>
                <td>
                    <button>Edit</button>
                    <button>Delete</button>
                </td>
            </tr>
        </tbody>
    </table>

    <form id="add-form">
        <h3>Add book</h3>
        <label>TITLE</label>
        <input type="text" name="title" placeholder="Title...">
        <label>AUTHOR</label>
        <input type="text" name="author" placeholder="Author...">
        <input type="submit" value="Submit">
    </form>

    <form id="edit-form">
        <input type="hidden" name="id">
        <h3>Edit book</h3>
        <label>TITLE</label>
        <input type="text" name="title" placeholder="Title...">
        <label>AUTHOR</label>
        <input type="text" name="author" placeholder="Author...">
        <input type="submit" value="Save">
    </form>*/