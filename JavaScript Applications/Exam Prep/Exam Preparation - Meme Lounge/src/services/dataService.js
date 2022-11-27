import * as request from './requester.js';

const endpoints = {
    getAllData: '/data/memes?sortBy=_createdOn%20desc',
    create: '/data/memes',
    details: (id) =>   `/data/memes/${id}`,
    edit: (id) =>  `/data/memes/${id}`,
    delete: (id) =>   `/data/memes/${id}`,
    getUserMemes: (userId) => `/data/memes?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`
}

export const getData = async () => {
    return await request.get(endpoints.getAllData);
}

export const createItem = async (data) => {
    return await request.post(endpoints.create, data);
}

export const getItem = async (id) => {
    return await request.get(endpoints.details(id));
}

export const editItem = async (id, data) => {
    return await request.put(endpoints.edit(id), data)
}

export const deleteItem = async (id) => {
    return await request.del(endpoints.delete(id));
}

export const getUserMemes = async (userId) => {
    return await request.get(endpoints.getUserMemes(userId))
}
