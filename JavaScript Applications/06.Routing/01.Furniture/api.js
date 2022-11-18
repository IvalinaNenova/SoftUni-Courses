const host = "http://localhost:3030";

async function request(url, method, data, token) {
  let options = {
    method,
    headers: {},
  };

  if (data !== undefined) {
    options.headers["content-type"] = "application/json";
    options.body = JSON.stringify(data);
  }

  if (token !== undefined) {
    options.headers["X-Authorization"] = token;
  }

  try {
    let response = await fetch(host + url, options);
    if (response.status == 204) {
      return response;
    }
    let data = await response.json();
    if (response.ok != true) {
      throw new Error(data.message);
    }
    return data;
  } catch (error) {
    alert(error.message);
    throw error;
  }
}

export async function getAllFurnitures() {
  return await request("/data/catalog", "get");
}

export async function getMyFurnitures(userId) {
  return await request(`/data/catalog?where=_ownerId%3D%22${userId}%22`, "get");
}

export async function onLogin(data) {
  return await request("/users/login", "post", data);
}

export async function onLogout() {
  let token = sessionStorage.token;
  return await request("/users/logout", "get", undefined, token);
}

export async function onRegister(data) {
  return await request("/users/register", "post", data);
}

export async function onCreate(data) {
  let token = sessionStorage.token;
  return await request("/data/catalog", "post", data, token);
}

export async function onDetails(id) {
  return await request("/data/catalog/" + id, "get");
}

export async function onUpdate(data, id) {
  let token = sessionStorage.token;
  return await request("/data/catalog/" + id, "put", data, token);
}

export async function onDelete(id) {
  let token = sessionStorage.token;
  return await request("/data/catalog/" + id, "delete", undefined, token);
}