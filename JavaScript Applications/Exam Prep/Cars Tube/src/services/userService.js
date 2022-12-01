import * as request from './requester.js';
import * as session from './sessionService.js';

const endpoints = {
    login: '/users/login',
    logout: '/users/logout',
    register: '/users/register'
}

export const login = async (username, password) => {
    let user = await request.post(endpoints.login, {username, password});
    session.setUser(user);
}

export const register = async (username, password) => {
    const user = await request.post(endpoints.register, {username, password});
    session.setUser(user);
}

export const logout = async() => {
    await request.get(endpoints.logout);
    session.removeUser();
};