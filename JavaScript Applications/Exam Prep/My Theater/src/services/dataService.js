import * as request from './requester.js';

const endpoints = {
    getAllData: '/data/theaters?sortBy=_createdOn%20desc&distinct=title',
    create: '/data/theaters',
    details: (id) =>  `/data/theaters/${id}`,
    edit: (id) =>  `/data/theaters/${id}`,
    delete: (id) =>  `/data/theaters/${id}`,
    myItems: (userId) => `/data/theaters?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`,
    addLike: '/data/likes',
    totalLikes: (theaterId ) => `/data/likes?where=theaterId%3D%22${theaterId}%22&distinct=_ownerId&count`,
    userLikes: (theaterId, userId) => `/data/likes?where=theaterId%3D%22${theaterId}%22%20and%20_ownerId%3D%22${userId}%22&count`
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

export const getMyItems = async (userId) => {
    return await request.get(endpoints.myItems(userId));
}

export const addLike = async (data) => {
    return await request.post(endpoints.addLike, data);
}

export const getLikes = async (theaterId) => {
    return await request.get(endpoints.totalLikes(theaterId));
}

export const getUserLikes = async (theaterId, userId) => {
    return await request.get(endpoints.userLikes(theaterId, userId));
}