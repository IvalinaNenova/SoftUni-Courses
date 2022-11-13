let url = 'http://localhost:3030/jsonstore/advanced/dropdown';

export async function get(){
    let response = await fetch(url);
    let result = await response.json();

    return [...Object.values(result)];
}

export async function post(data){
    return await fetch(url, {
        method: 'POST',
        headers: {'Content-Type': 'application/json'},
        body: JSON.stringify(data)
    });
}