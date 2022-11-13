const baseUrl = 'http://localhost:3030/jsonstore/collections/books'
export async function get(){
    let response = await fetch(baseUrl);
    let result = await response.json();

    return [...Object.entries(result)];
}

export async function post({author, title}){
    return await fetch(baseUrl, {
        method: 'POST',
        headers: {'Content-Type': 'application/json'},
        body: JSON.stringify({author, title})
    });
}

export async function put(id, data){
    let response = await fetch(`${baseUrl}/${id}`, {
        method: 'PUT',
        headers: {'Content-Type': 'application/json'},
        body: JSON.stringify(data)
    });

}

export async function del(id){
    return await fetch(`${baseUrl}/${id}`, {
        method: 'DELETE'
    });
}