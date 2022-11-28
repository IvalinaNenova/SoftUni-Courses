import * as request from './requester.js';

const endpoints = {
    getAllData: '/data/games?sortBy=_createdOn%20desc',
    getMostRecent: '/data/games?sortBy=_createdOn%20desc&distinct=category',
    create: '/data/games',
    details: (id) =>  `/data/games/${id}`,
    edit: (id) =>  `/data/games/${id}`,
    delete: (id) =>  `/data/games/${id}`,
    addComment: '/data/comments',
    getGameComments: (gameId) => `/data/comments?where=gameId%3D%22${gameId}%22`,
}

export const getData = async () => {
    return await request.get(endpoints.getAllData);
}
export const getMostRecent = async () => {
    return await request.get(endpoints.getMostRecent);
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

export const getComments = async (id) => {
    return await request.get(endpoints.getGameComments(id));
}

export const addComment = async (data) => {
    return await request.post(endpoints.addComment, data);
}
