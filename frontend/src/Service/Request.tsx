import axios from 'axios';

const api = axios.create({
    baseURL: 'https://localhost:7059/',
});


export const requestData = async (endpoint: string) => {
    const { data } = await api.get(endpoint);
    return data;
};

export const sendData = async (endpoint: string, data: object) => {
    await api.post(endpoint, data);
}