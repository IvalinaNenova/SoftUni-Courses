const section = document.getElementById("detailsView");
const main = document.getElementsByTagName("main")[0];
const form = section.querySelector("form");
form.addEventListener("submit", onSubmit);
const themeContentWrapper = document.getElementById("theme-content-wrapper");
 
section.remove();
let id;
 
export async function showDetails(e) {
    if (!e) {
        return
    }
 
    if (e.target.tagName == "H2") {
        id = e.target.parentElement.id
    } else if (e.target.tagName == "A") {
        id = e.target.id
    }
    appendElement();
 
}
 
async function appendElement() {
    const topic = await loadTopic(id)
    const comments = await loadComment(id)
 
    const res = topicTemplate(topic, comments);//tbd
    themeContentWrapper.replaceChildren(res);
    main.replaceChildren(section)
}
 
function topicTemplate(topic, comments) {
 
    const topicContainer = document.createElement("div");
    topicContainer.classList.add("theme-title");
    topicContainer.innerHTML = `
                        <div class="theme-name-wrapper">
                            <div class="theme-name">
                                <h2>${topic.topicName}</h2>
                            </div>
                        </div>
    `
    const commentContainer = document.createElement("div");
    commentContainer.classList.add("comment");
 
    commentContainer.innerHTML = `
    <div class="header">
        <img src="./static/profile.png" alt="avatar">
        <p><span>${topic.username}</span> posted on <time>${topic.date}</time></p>
 
    <p class="post-content">${topic.postText}</p>
    </div>
   `
    comments.forEach(x => {
        const comment = createComment(x);
        commentContainer.appendChild(comment);
    })
 
    return commentContainer;
}
 
function createComment(data) {
    const container = document.createElement("div")
    container.classList.add("user-comment")
    container.innerHTML = `
        <div class="topic-name-wrapper">
            <div class="topic-name">
                <p><strong>${data.username}</strong> commented on <time>${data.date}</time></p>
                <div class="post-content">
                 <p>${data.postText}</p>
              </div>
            </div>
        </div>
        `
    return container;
}
 
function onSubmit(e) {
    e.preventDefault();
    const formData = new FormData(form);
    const { postText, username } = Object.fromEntries(formData);
    cretePost({ postText, username, id, date: new Date() });
}
 
async function cretePost(body) {
    const url = "http://localhost:3030/jsonstore/collections/myboard/comments";
 
    try {
        const response = await fetch(url, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(body)
        })
        if (!response.ok) {
            const err = await response.json();
            throw new Error(err.message);
        }
        appendElement();
        clearForm();
    } catch (error) {
        alert(error.message)
    }
 
}
 
function clearForm() {
    form.reset();
}
 
async function loadComment(id) {
    const url = "http://localhost:3030/jsonstore/collections/myboard/comments"// TODO id??
    try {
        const response = await fetch(url);
        const data = await response.json();
        if (!response.ok){
            const error = data;
            throw new Error(error.message);
        }
        
        const filterData = Object.values(data).filter(x => x.id === id)
        return filterData
    } catch(error){
        alert(error.message)
    }
    
}
 
async function loadTopic(id) {
    const url = `http://localhost:3030/jsonstore/collections/myboard/posts/${id}`;
 
    try {
        const response = await fetch(url);
        const data = await response.json();
        if(!response.ok){
            const error = data
            throw new Error(error.message);
        }
        return data
    } catch(error){
        alert(error.message)
    }
    
}