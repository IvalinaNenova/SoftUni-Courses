export const getUser = () => {
    return JSON.parse(sessionStorage.getItem('userData'));
};

export const setUser = (data) => {
    sessionStorage.setItem('userData', JSON.stringify(data));
};

export const removeUser = () => sessionStorage.clear();