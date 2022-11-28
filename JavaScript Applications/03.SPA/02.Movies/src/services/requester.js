import { getUser } from './sessionService.js';
const baseUrl = 'http://localhost:3030'

async function request(method, url, data) {
    let options = {
        method,
        headers: {},
    };

    if (data !== undefined) {
        options.headers["content-type"] = "application/json";
        options.body = JSON.stringify(data);
    }
    const user = getUser();
    if (user) {
        options.headers["X-Authorization"] = user.accessToken;
    }

    try {
        let response = await fetch(baseUrl + url, options);

        if (response.status == 204) {
            return response;
        }

        let data = await response.json();

        if (response.ok != true) {
            throw new Error(data.message);
        }

        return data;
        
    } catch (error) {
        alert(error.message);
        throw error;
    }
}

export const get = request.bind({}, 'GET');
export const post = request.bind({}, 'POST');
export const put = request.bind({}, 'PUT');
export const del = request.bind({}, 'DELETE');