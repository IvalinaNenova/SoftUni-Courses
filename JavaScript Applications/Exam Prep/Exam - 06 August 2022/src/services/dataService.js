import * as request from './requester.js';

const endpoints = {
    getAllData: '/data/offers?sortBy=_createdOn%20desc',
    create: '/data/offers',
    details: (id) =>  `/data/offers/${id}`,
    edit: (id) =>  `/data/offers/${id}`,
    delete: (id) =>  `/data/offers/${id}`,
    addApplication: `/data/applications`,
    getCountApplications: (offerId) => `/data/applications?where=offerId%3D%22${offerId}%22&distinct=_ownerId&count`,
    getUserApplications: (offerId, userId) => `/data/applications?where=offerId%3D%22${offerId}%22%20and%20_ownerId%3D%22${userId}%22&count`
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

export const addApplication = async (data) => {
    return await request.post(endpoints.addApplication, data);
}
export const getCount = async (offerId) => {
    return await request.get(endpoints.getCountApplications(offerId));
}

export const getUserApplications = async (offerId, userId ) => {
    return await request.get(endpoints.getUserApplications(offerId, userId));
}