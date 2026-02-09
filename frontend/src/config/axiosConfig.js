import axios from 'axios';

const api = axios.create({
    baseURL: 'http://localhost:5149/api',
    headers: {
        'Content-Type': 'application/json',
    },
});

// Add a request interceptor to attach the token
api.interceptors.request.use(
    (config) => {
        const isAdminRoute = window.location.pathname.startsWith('/admin');
        const token = isAdminRoute ? localStorage.getItem('adminToken') : localStorage.getItem('token');

        if (token) {
            config.headers.Authorization = `Bearer ${token}`;
        }
        return config;
    },
    (error) => Promise.reject(error)
);

// Add a response interceptor to handle 401 errors
api.interceptors.response.use(
    (response) => response,
    (error) => {
        if (error.response && error.response.status === 401) {
            // Clear local storage and redirect to login if token is invalid/expired
            const isAdminRoute = window.location.pathname.startsWith('/admin');

            if (isAdminRoute) {
                localStorage.removeItem('adminToken');
                localStorage.removeItem('adminUser');
                window.location.href = '/admin/login';
            } else {
                localStorage.removeItem('token');
                localStorage.removeItem('user');
                window.location.href = '/login';
            }
        }
        return Promise.reject(error);
    }
);

export default api;
