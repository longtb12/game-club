import axios from 'axios';

// Set up axios instance with default settings
const apiClient = axios.create({
    baseURL: 'https://localhost:5000/api', 
    headers: {
        'Content-Type': 'application/json',
    },
});

const apiService = {
    async createClub(clubData) {
        const response = await apiClient.post('/clubs', clubData);
        return response.data;
    },

    async getAllClubs() {
        const response = await apiClient.get('/clubs');
        return response.data;
    },

    async searchClubs(searchTerm) {
        const response = await apiClient.get('/clubs', {
            params: { search: searchTerm },
        });
        return response.data;
    },

    async createEvent(clubId, eventData) {
        const response = await apiClient.post(`/clubs/${clubId}/events`, eventData);
        return response.data;
    },

    async getEventsForClub(clubId) {
        const response = await apiClient.get(`/clubs/${clubId}/events`);
        return response.data;
    },
};

export default apiService;
