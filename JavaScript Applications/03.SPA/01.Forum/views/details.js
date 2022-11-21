import { getPosts, postContent } from '../api.js';
import { render, html } from '../node_modules/lit-html/lit-html.js'

function detailsTemplate() {
    return html`
    <div class="container">
        <!-- theme content  -->
        <div class="theme-content">
            <!-- theme-title  -->
            <div class="theme-title">
                <div class="theme-name-wrapper">
                    <div class="theme-name">
                        <h2>Angular 10</h2>
    
                    </div>
    
                </div>
            </div>
            <!-- comment  -->
    
            <div class="comment">
    
            </div>
    
            <div class="answer-comment">
                <p><span>currentUser</span> comment:</p>
                <div class="answer">
                    <form>
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
    </div>
    `
}

export async function detailsView(ctx){
    console.log();
    render(detailsTemplate(), document.querySelector('#root'));
}