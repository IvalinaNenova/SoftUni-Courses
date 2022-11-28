import * as request from './requester.js';

const endpoints = {
    getAllData: '/data/movies',
    create: '/data/movies ',
    details: (id) => `/data/movies/${id}`,
    edit: (id) =>  `/data/movies/${id}`,
    delete: (id) =>  `/data/movies/${id}`,
    like: '/data/likes',
    dislike: (movieId) => `/data/likes/${movieId}`,
    getCountLikes: (movieId) => `/data/likes?where=movieId%3D%22${movieId}%22&distinct=_ownerId&count`,
    getUserLikes: (movieId, userId) => `/data/likes?where=movieId%3D%22${movieId}%22%20and%20_ownerId%3D%22${userId}%22`
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

export const getMovieLikes = async (movieId) => {
    return await request.get(endpoints.getCountLikes(movieId));
}

export const getUserLikes = async (movieId, userId) => {
    return await request.get(endpoints.getUserLikes(movieId, userId));
}

export const likeMovie = async (data) => {
    return await request.post(endpoints.like, data)
}

export const dislikeMovie = async (movieId) => {
    return await request.del(endpoints.dislike(movieId));
}
