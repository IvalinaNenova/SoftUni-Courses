import * as request from './requester.js';

const endpoints = {
    getAllData: '/data/posts?sortBy=_createdOn%20desc',
    create: '/data/posts',
    details: (id) =>  `/data/posts/${id}`,
    edit: (id) =>  `/data/posts/${id}`,
    delete: (id) =>  `/data/posts/${id}`,
    myPosts: (userId) => `/data/posts?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`,
    donate: `/data/donations`,
    totalDonations : (postId) => `/data/donations?where=postId%3D%22${postId}%22&distinct=_ownerId&count`,
    userDonations: (postId, userId) => `/data/donations?where=postId%3D%22${postId}%22%20and%20_ownerId%3D%22${userId}%22&count`

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

export const myPosts = async (userId) => {
    return await request.get(endpoints.myPosts(userId));
}

export const donate = async (data) => {
    return await request.post(endpoints.donate, data);
}

export const getCount = async (postId) => {
    return await request.get(endpoints.totalDonations(postId));
}

export const getUserDonations = async (postId, userId) => {
    return await request.get(endpoints.userDonations(postId, userId));
}
