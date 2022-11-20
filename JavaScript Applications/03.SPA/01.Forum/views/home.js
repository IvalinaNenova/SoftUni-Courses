import { getPosts, postContent } from '../api.js';
import { render, html } from '../node_modules/lit-html/lit-html.js'

function homeTemplate(posts) {
    return html`
    <!-- homepage -->
    <div class="container">
        <main>
            <div class="new-topic-border">
                <div class="header-background">
                    <span>New Topic</span>
                </div>
                <form>
                    <div class="new-topic-title">
                        <label for="topicName">Title <span class="red">*</span></label>
                        <input type="text" name="topicName" id="topicName">
                    </div>
                    <div class="new-topic-title">
                        <label for="username">Username <span class="red">*</span></label>
                        <input type="text" name="username" id="username">
                    </div>
                    <div class="new-topic-content">
                        <label for="postText">Post <span class="red">*</span></label>
                        <textarea type="text" name="postText" id="postText" rows="8" class="height"></textarea>
                    </div>
                    <div class="new-topic-buttons">
                        <button @click=${onCancel} class="cancel">Cancel</button>
                        <button @click=${onSubmit} class="public">Post</button>
                    </div>
    
                </form>
            </div>
    
            <div class="topic-title">
                <!-- topic component  -->
                <div class="topic-container">
                    ${posts? posts.map(p => html`
                    <div class="topic-name-wrapper">
                        <div class="topic-name">
                            <a .id=${p._id} href="#" class="normal">
                                <h2>${p.title}</h2>
                            </a>
                            <div class="columns">
                                <div>
                                    <p>Date: <time>2020-10-10T12:08:28.451Z</time></p>
                                    <div class="nick-name">
                                        <p>Username: <span>${p.username}</span></p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    `) : null}
                </div>
            </div>
        </main>
    </div>
    `
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

export async function homeView() {
    let posts = await getPosts();
    render(homeTemplate(posts), document.querySelector('#root'));
}