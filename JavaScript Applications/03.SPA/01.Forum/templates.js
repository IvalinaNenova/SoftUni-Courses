import { html } from '../node_modules/lit-html/lit-html.js'
export function homeTemplate(posts, sumbit, cancel, details) {
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
                            <button @click=${cancel} class="cancel">Cancel</button>
                            <button @click=${sumbit} class="public">Post</button>
                        </div>
        
                    </form>
                </div>
        
                <div class="topic-title">
                    <!-- topic component  -->
                    <div class="topic-container">
                        ${posts ? posts.map(p => html`
                        <div class="topic-name-wrapper">
                            <div class="topic-name">
                                <a .id="${p._id}" @click=${details} href="#" class="normal">
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

export function detailsTemplate(onComment, topic, comments) {
    return html`
    <div class="container">
        <!-- theme content  -->
        <div class="theme-content">
            <!-- theme-title  -->
            <div class="theme-title">
                <div class="theme-name-wrapper">
                    <div class="theme-name">
                        <h2 .id=${topic._id}>${topic.title}</h2>
    
                    </div>
    
                </div>
            </div>
            <!-- comment  -->
            <div class="comment">
                <div class="header">
                    <img src="./static/profile.png" alt="avatar">
                    <p><span>${topic.username}</span> posted on <time>2020-10-10 12:08:28</time></p>
    
                    <p class="post-content">${topic.content}</p>
                </div>
                ${comments ? comments.map(c => html`
                <div id="user-comment">
                    <div class="topic-name-wrapper">
                        <div class="topic-name">
                            <p><strong>${c.username}</strong> commented on <time>3/15/2021, 12:39:02 AM</time></p>
                            <div class="post-content">
                                <p>${c.content}</p>
                            </div>
                        </div>
                    </div>
                </div>
                `) : null}
            </div>
            <div class="answer-comment">
                <p><span>currentUser</span> comment:</p>
                <div class="answer">
                    <form @submit=${onComment}>
                        <textarea name="postText" id="comment" cols="30" rows="10"></textarea>
                        <div>
                            <label for="username">Username <span class="red">*</span></label>
                            <input type="text" name="username" id="username">
                        </div>
                        <button>Post</button>
                    </form>
                </div>
            </div>
        </div>
    `
}