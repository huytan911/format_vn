import React, { createContext, useState, useContext, useEffect } from 'react';
import api from '../config/axiosConfig';

const AuthContext = createContext(null);

export const AuthProvider = ({ children }) => {
    const [user, setUser] = useState(null);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        // Check for stored token and user on mount
        const storedToken = localStorage.getItem('token');
        const storedUser = localStorage.getItem('user');

        if (storedToken && storedUser) {
            setUser(JSON.parse(storedUser));
        }
        setLoading(false);
    }, []);

    const login = async (email, password, isAdmin = false) => {
        try {
            const endpoint = isAdmin ? '/auth/login' : '/auth/customer/login';
            const response = await api.post(endpoint, { email, password });
            const { token, ...userData } = response.data;

            localStorage.setItem('token', token);

            const userObj = {
                name: userData.username || userData.name,
                email: userData.email,
                role: userData.role
            };

            localStorage.setItem('user', JSON.stringify(userObj));
            setUser(userObj);

            return { success: true };
        } catch (error) {
            console.error('Login error:', error);
            return {
                success: false,
                message: error.response?.data?.message || 'Đăng nhập thất bại. Vui lòng kiểm tra lại.'
            };
        }
    };

    const register = async (registerData) => {
        try {
            const response = await api.post('/auth/customer/register', registerData);
            const { token, ...userData } = response.data;

            localStorage.setItem('token', token);

            const userObj = {
                name: userData.name,
                email: userData.email,
                role: userData.role
            };

            localStorage.setItem('user', JSON.stringify(userObj));
            setUser(userObj);

            return { success: true };
        } catch (error) {
            console.error('Registration error:', error);
            return {
                success: false,
                message: error.response?.data?.message || 'Đăng ký thất bại. Vui lòng thử lại.'
            };
        }
    };

    const logout = () => {
        const role = user?.role;
        localStorage.removeItem('token');
        localStorage.removeItem('user');
        setUser(null);

        // Use window.location.href to fully reset the application state on logout
        if (role === 'Customer') {
            window.location.href = '/';
        } else {
            window.location.href = '/login';
        }
    };

    return (
        <AuthContext.Provider value={{ user, login, register, logout, loading, isAuthenticated: !!user, isAdmin: user?.role !== 'Customer' && !!user }}>
            {!loading && children}
        </AuthContext.Provider>
    );
};

export const useAuth = () => useContext(AuthContext);
