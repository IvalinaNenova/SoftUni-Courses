import { showDetails } from './details.js';
 
const section = document.getElementById("homeView");
const main = document.getElementsByTagName("main")[0];
const form = document.querySelector("#homeView form");
form.addEventListener("submit", onSubmit);
const url = "http://localhost:3030/jsonstore/collections/myboard/posts";
 
section.remove();
 
export async function showHome() {
    const topicContainer = section.querySelector(".topic-title");
 
    const posts = await loadPost();
    const content = Object.values(posts).map(x=> topicTemplate(x))
    topicContainer.replaceChildren(...content);
    main.replaceChildren(section);
}
 
function topicTemplate(data) {
    const container = document.createElement("div");
    container.classList.add("topic-container");
    container.innerHTML = `
    <div class="topic-name-wrapper" >
        <div class="topic-name">
        <a href="#" class="normal" id="${data._id}">
            <h2>${data.topicName}</h2>
        </a>
        <div class="columns">
            <div>
                <p>Date: <time>${data.date}</time></p>
                <div class="nick-name">
                    <p>Username: <span>${data.username}</span></p>
                </div>
            </div>
        </div>
        </div>
    </div>`;
   
    container.querySelector("a").addEventListener("click", showDetails)
    return container;
}
 
function onSubmit(e) {
    e.preventDefault();
    if (e.submitter.innerHTML === "Cancel") {
        form.reset();
        return;
    }
    const formData = new FormData(form);
    const { topicName, username, postText } = Object.fromEntries(formData);
 
    createPost({ topicName, username, postText, date : new Date() })
    clearForm();
}
 
function clearForm() {
    form.reset()
}
 
async function createPost(body) {
    try {
        if (Object.values(body).includes('')) {
            throw new Error('All fields must be provided');
        }
        const response = await fetch(url, {
            method: "POST",
            headers: { "Content-type": "application/json" },
            body: JSON.stringify(body)
        })
        const data = await response.json();
        if(!response.ok){
            const error = data.message;
            throw new Error(error)
        }
        showHome();
    } catch (error) {
        alert(error.message)
    }
   
}
 
async function loadPost() {
    try {
        const response = await fetch(url);
        const data = await response.json();
        if (!response.ok){
            const err = response.message;
            throw new Error(err)
        }
        return data;
    }catch (err){
        alert(err.message);
    }
}
 
 
showDetails()