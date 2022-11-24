export const getUser = () => {
    let user = sessionStorage.getItem('userData');
    if(user) {
        return JSON.parse(user);
    } else {
        return undefined;
    }
};

export const setUser = (data) => {
    sessionStorage.setItem('userData', JSON.stringify(data));
};

export const removeUser = () => sessionStorage.clear();