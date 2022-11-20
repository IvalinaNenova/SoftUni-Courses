let baseUrl = 'http://localhost:3030/jsonstore/collections/myboard/';
export async function getPosts(){
    let response = await fetch(baseUrl + 'posts');
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