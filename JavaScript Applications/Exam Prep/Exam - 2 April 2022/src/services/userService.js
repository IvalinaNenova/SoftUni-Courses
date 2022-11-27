import * as request from './requester.js';
import * as session from './sessionService.js';

const endpoints = {
    login: '/users/login',
    logout: '/users/logout',
    register: '/users/register'
}

export const login = async (email, password) => {
    let user = await request.post(endpoints.login, {email, password});
    session.setUser(user);
}

export const register = async (email, password) => {
    const user = await request.post(endpoints.register, {email, password});
    session.setUser(user);
}

export const logout = async() => {
    await request.get(endpoints.logout);
    session.removeUser();
};