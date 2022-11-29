import { html } from '../../node_modules/lit-html/lit-html.js';
import { myItems } from '../services/dataService.js';

function bookCard(book) {
    return html`
    <li class="otherBooks">
        <h3>${book.title}</h3>
        <p>Type: ${book.type}</p>
        <p class="img"><img src="${book.imageUrl}"></p>
        <a class="button" href="/details/${book._id}">Details</a>
    </li>
    `
}

function myBooksTemplate(books) {
    return html`
<section id="my-books-page" class="my-books">
    <h1>My Books</h1>

    <ul class="my-books-list">

        ${books.length > 0
        ? books.map(b=> bookCard(b))
        : html`<p class="no-books">No books in database!</p>`}
        
    </ul>
    
</section>

`}
export async function myBooksView (ctx) {
    let myBooks = await myItems(ctx.user._id)
    ctx.render(myBooksTemplate(myBooks));
}