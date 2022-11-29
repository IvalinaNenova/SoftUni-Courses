import * as api from '../api.js';

const endpoints = {
    getAllData: '/data/books?sortBy=_createdOn%20desc',
    create: '/data/books',
    details: (id) => `/data/books/${id}`,
    edit: (id) => `/data/books/${id}`,
    delete: (id) => `/data/books/${id}`,
    myItems: (userId) => `/data/books?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`,
    addLike: '/data/likes',
    countLikes: (bookId) => `/data/likes?where=bookId%3D%22${bookId}%22&distinct=_ownerId&count`,
    userLikes: (bookId, userId) => `/data/likes?where=bookId%3D%22${bookId}%22%20and%20_ownerId%3D%22${userId}%22&count`
}

export async function getAllItems() {
    return await api.get(endpoints.getAllData);
}

export async function createItem(data) {
    return await api.post(endpoints.create, data);
}

export async function getItem(id) {
    return await api.get(endpoints.details(id));
}

export async function editItem(id, data) {
    return await api.put(endpoints.edit(id), data)
}

export async function deleteItem(id) {
    return await api.del(endpoints.delete(id));
}

export async function myItems(userId) {
    return await api.get(endpoints.myItems(userId));
}

export async function addLike(data) {
    return await api.post(endpoints.addLike, data);
}

export async function totalLikes(bookId) {
    return await api.get(endpoints.countLikes(bookId));
}

export async function userLikes(bookId, userId) {
    return await api.get(endpoints.userLikes(bookId, userId));
}
