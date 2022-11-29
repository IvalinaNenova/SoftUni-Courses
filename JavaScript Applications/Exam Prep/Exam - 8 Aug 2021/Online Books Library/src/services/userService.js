import * as api from '../api.js';
import * as session from './authService.js';


export const login = async (data) => {
    let user = await api.post('/users/login', data);
    session.setUser(user);
}

export const register = async (data) => {
    const user = await api.post('/users/register', data);
    session.setUser(user);
}

export const logout = async() => {
    await api.get('/users/logout');
    session.removeUser();
};