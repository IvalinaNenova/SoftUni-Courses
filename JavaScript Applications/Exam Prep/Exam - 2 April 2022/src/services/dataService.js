import * as request from './requester.js';

const endpoints = {
    getAllData: '/data/pets?sortBy=_createdOn%20desc&distinct=name',
    create: '/data/pets',
    details: (id) => `/data/pets/${id}`,
    edit: (id) => `/data/pets/${id}`,
    delete: (id) => `/data/pets/${id}`,
    donation: '/data/donation',
    total: (petId) => `/data/donation?where=petId%3D%22${petId}%22&distinct=_ownerId&count`,
    own: (petId, userId) =>
        `/data/donation?where=petId%3D%22${petId}%22%20and%20_ownerId%3D%22${userId}%22&count`,
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

export const donate = async (data) => {
    return await request.post(endpoints.donation, data);
}

export const getTotalCount = async (petId) => {
    return await request.get(endpoints.total(petId));
}

export const getUserDonations = async (petId, userId) => {
    return await request.get(endpoints.own(petId, userId));
}