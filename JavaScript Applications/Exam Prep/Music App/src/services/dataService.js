import * as request from './requester.js';

const endpoints = {
    getAllData: '/data/albums?sortBy=_createdOn%20desc&distinct=name',
    create: '/data/albums',
    details: (id) =>  `/data/albums/${id}`,
    edit: (id) =>  `/data/albums/${id}`,
    delete: (id) =>  `/data/albums/${id}`,
    search: (query) => `/data/albums?where=name%20LIKE%20%22${query}%22`
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

export const search = async (query) => {
    return request.get(endpoints.search(query));
}
