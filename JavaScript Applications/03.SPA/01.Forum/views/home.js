import { getPosts, postContent, getPost, postComment, getComments } from '../api.js';
import { render, html } from '../node_modules/lit-html/lit-html.js'
import { homeTemplate, detailsTemplate } from '../templates.js';

function onDetails(ev) {
    let target = ev.target;
    console.log(ev.target);
    if (target.tagName === "H2") {
        target = target.parentElement;
        detailsView(target.id)
    }
    if (target.tagName === "A") {
        detailsView(target.id);
    }
}
function onCancel(e) {
    e.preventDefault()
    let form = document.querySelector('form');
    let formData = new FormData(form);
    formData.set('topicName', '');
    formData.set('username', '');
    formData.set('postText', '');

    form.reset();
}
async function onSubmit(e) {
    e.preventDefault();
    let form = document.querySelector('form');
    let formData = new FormData(form);
    let inputs = [...formData.values()]

    if (inputs.includes('')) return alert('All fields are required');

    let title = formData.get('topicName');
    let username = formData.get('username');
    let content = formData.get('postText');

    await postContent({ title, username, content }, 'posts')
    form.reset()
    homeView()
}

async function onComment(e){
    e.preventDefault();
    let form = document.querySelector('form');
    let topicId = document.querySelector('h2').id;
    let formData = new FormData(form);
    let inputs = [...formData.values()]

    if (inputs.includes('')) return alert('All fields are required');

    let username = formData.get('username');
    let content = formData.get('postText');

    await postComment({username, content, topicId});
    form.reset();
    console.log(username, content, topicId);
    detailsView(topicId);
}

export async function homeView(ctx) {
    let posts = await getPosts('posts');
    render(homeTemplate(posts, onSubmit, onCancel, onDetails), document.querySelector('#root'));
}

async function detailsView(id){
    let post = await getPost (id);
    let comments = await getComments();
    comments = comments.filter(comment => comment.topicId == id);
    render(detailsTemplate(onComment, post, comments), document.querySelector('#root'));
}