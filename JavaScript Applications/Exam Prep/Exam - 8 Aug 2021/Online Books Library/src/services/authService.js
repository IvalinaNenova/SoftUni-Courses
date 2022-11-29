export function getUser() {
    return JSON.parse(sessionStorage.getItem('userData'));
};

export function setUser(data) {
    sessionStorage.setItem('userData', JSON.stringify(data));
};

export function removeUser() { sessionStorage.clear(); }