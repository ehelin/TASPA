import axios from 'axios';

const apiBaseUrl = 'http://localhost:8055'; 

const apiService = axios.create({
    baseURL: apiBaseUrl,
    timeout: 60000, 
});

export default apiService;