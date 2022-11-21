let baseUrl = 'http://localhost:3030/jsonstore/collections/myboard/';
export async function getPosts(endpoint){
    let response = await fetch(baseUrl + endpoint);
    let result = await response.json();
    console.log(Object.entries(result));
    return Object.values(result);
}

export async function postContent(data, endpoint){
    let response = await fetch(baseUrl + endpoint, {
        method: 'POST',
        headers: {'Content-Type': 'application/json'},
        body: JSON.stringify(data)
    });
    let result = await response.json();
    console.log(result);
}

export async function getPost(endpoint){
    let response = await fetch('http://localhost:3030/jsonstore/collections/myboard/posts/' + endpoint);
    let result = await response.json();
    return result;
}

export async function getComments(){
    let response = await fetch(baseUrl + 'comments');
    let result = await response.json();
    return [...Object.values(result)];
}

export async function postComment(data){
    let response = await fetch(baseUrl + 'comments', {
        method: 'POST',
        headers: {'Content-Type': 'application/json'},
        body : JSON.stringify(data)
    })
}