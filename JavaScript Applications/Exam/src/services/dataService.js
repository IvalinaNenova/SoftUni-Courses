import * as request from './requester.js';

const endpoints = {
    getAllData: '/data/albums?sortBy=_createdOn%20desc',
    create: '/data/albums',
    details: (id) => `/data/albums/${id}`,
    edit: (id) => `/data/albums/${id}`,
    delete: (id) => `/data/albums/${id}`,
    addLike: '/data/likes',
    totalLikes: (albumId) => `/data/likes?where=albumId%3D%22${albumId}%22&distinct=_ownerId&count`,
    userLikes: (albumId, userId) => `/data/likes?where=albumId%3D%22${albumId}%22%20and%20_ownerId%3D%22${userId}%22&count`
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

export const addLike = async (data) => {
    return await request.post(endpoints.addLike, data);
}

export const getTotalLikes = async (albumId) => {
    return request.get(endpoints.totalLikes(albumId));
}

export const getUserLikes = async (albumId, userId) => {
    return request.get(endpoints.userLikes(albumId, userId));
}