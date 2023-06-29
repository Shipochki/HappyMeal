import { requestFactory } from './requester';

const baseUrl = 'http://localhost:44433/api/restaurant';

export const restaurantServiceFactory = (token) => {
    const request = requestFactory(token);

    const getAll = async () => {
        const result = await request.get(baseUrl + '/getall');
        const restaurants = Object.values(result);
    
        return restaurants;
    };
    
    return {
        getAll,
    };
}