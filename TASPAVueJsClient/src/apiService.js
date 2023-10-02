import axios from 'axios';
const apiBaseUrl = 'http://localhost:8055'; // Replace with your API's URL
const apiService = axios.create({
    baseURL: apiBaseUrl,
    timeout: 5000, // Adjust the timeout as needed
});
export default apiService;