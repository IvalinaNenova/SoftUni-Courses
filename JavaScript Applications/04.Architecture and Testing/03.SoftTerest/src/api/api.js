const host = 'http://localhost:3030';
async function request(url, options){
    try {
        let response = await fetch(`${host}${url}`, options);

        if (response.ok == false){
            if (response.status === 403) {
                //REMOVE THE TOKEN
                sessionStorage.removeItem('userData');
            }
            const error = await response.json();
            throw new Error(error.message);
        }

        if (response.status === 204) {
            return response;
        }else{
            return response.json();
        }
    } catch (error) {
        alert(error.message);
        //throw error;
    }
}

function createOptions(method = 'GET', data){
    let options = {
        method,
        headers: {}
    }

    if (data != undefined) {
        options.headers['Content-Type'] = 'application/json';
        options.body = JSON.stringify(data);
    }

    let userData = JSON.parse(sessionStorage.getItem('userData'));

    if (userData) {
        options.headers['X-Authorization'] = userData.token;
    }

    return options;
}

export async function get(url){
    return request(url, createOptions);
}
export async function post(url, data){
    return request(url, createOptions('post', data));
}
export async function put(url, data){
    return request(url, createOptions('put', data));
}

export async function del(url){
    return request(url, createOptions('delete'));
}

export async function login(email, password){
    let result = await post('/users/login', {email, password});

    let userData = {
        email: result.email,
        id: result._id,
        token: result.accessToken
    }

    sessionStorage.setItem('userData', JSON.stringify(userData));
}
export async function logout(){
    await get('/users/logout');
    sessionStorage.removeItem('userData')
}

export async function register(email, password){
    let result = await post('/users/register', {email, password})

    //TODO: extract to utility func
    let userData = {
        email: result.email,
        id: result._id,
        token: result.accessToken
    }

    sessionStorage.setItem('userData', JSON.stringify(userData));
}