import * as request from './requester.js';

const endpoints = {
    getAllData: '/data/cars?sortBy=_createdOn%20desc',
    create: '/data/cars',
    details: (id) =>  `/data/cars/${id}`,
    edit: (id) =>  `/data/cars/${id}`,
    delete: (id) =>  `/data/cars/${id}`,
    myListings: (userId) =>  `/data/cars?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`,
    filter: (query) => `/data/cars?where=year%3D${query}`
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

export const getMyListings = async (userId) => {
    return await request.get(endpoints.myListings(userId));
}

export const search = async (query) => {
    return await request.get(endpoints.filter(query));
}
