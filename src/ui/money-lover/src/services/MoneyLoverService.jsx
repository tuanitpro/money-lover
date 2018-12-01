import axios from 'axios';
const apiUrl = 'https://localhost:44344/api/v1';
const MoneyLoverService = {
    async   getCategories() {
        const response = await axios.get(apiUrl + '/category');
        return response.data;
    },

    async  getEvents(start, end) {
        const response = await axios.get(apiUrl + '/events?start=' + start + '&end=' + end);
        return response.data;
    },

    async  addEvent(model) {
        const response = axios.post(apiUrl + '/events', model);
        return response.data;
    }
};

export default MoneyLoverService;