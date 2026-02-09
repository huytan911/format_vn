import React, { createContext, useState, useContext, useEffect } from 'react';
import api from '../config/axiosConfig';

const AuthContext = createContext(null);

export const AuthProvider = ({ children }) => {
    // Customer state
    const [user, setUser] = useState(null);
    // Admin state
    const [adminUser, setAdminUser] = useState(null);

    const [loading, setLoading] = useState(true);

    useEffect(() => {
        try {
            // Check for stored customer
            const storedToken = localStorage.getItem('token');
            const storedUser = localStorage.getItem('user');
            if (storedToken && storedUser) {
                try {
                    setUser(JSON.parse(storedUser));
                } catch (e) {
                    console.error('Error parsing stored user:', e);
                    localStorage.removeItem('user');
                    localStorage.removeItem('token');
                }
            }

            // Check for stored admin
            const storedAdminToken = localStorage.getItem('adminToken');
            const storedAdminUser = localStorage.getItem('adminUser');
            if (storedAdminToken && storedAdminUser) {
                try {
                    setAdminUser(JSON.parse(storedAdminUser));
                } catch (e) {
                    console.error('Error parsing stored admin user:', e);
                    localStorage.removeItem('adminUser');
                    localStorage.removeItem('adminToken');
                }
            }
        } catch (error) {
            console.error('Error initializing auth:', error);
        } finally {
            setLoading(false);
        }
    }, []);

    const login = async (email, password, isAdmin = false) => {
        try {
            const endpoint = isAdmin ? '/auth/login' : '/auth/customer/login';
            const response = await api.post(endpoint, { email, password });
            const { token, ...userData } = response.data;

            if (isAdmin) {
                localStorage.setItem('adminToken', token);
                const userObj = {
                    name: userData.username || userData.name,
                    username: userData.username, // specific to admin
                    email: userData.email,
                    role: userData.role
                };
                localStorage.setItem('adminUser', JSON.stringify(userObj));
                setAdminUser(userObj);
            } else {
                localStorage.setItem('token', token);
                const userObj = {
                    name: userData.username || userData.name,
                    email: userData.email,
                    role: userData.role
                };
                localStorage.setItem('user', JSON.stringify(userObj));
                setUser(userObj);
            }

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

    const logout = (type = 'customer') => {
        if (type === 'admin') {
            localStorage.removeItem('adminToken');
            localStorage.removeItem('adminUser');
            setAdminUser(null);
            window.location.href = '/admin/login';
        } else {
            localStorage.removeItem('token');
            localStorage.removeItem('user');
            setUser(null);
            window.location.href = '/';
        }
    };

    return (
        <AuthContext.Provider value={{
            user, // Customer user
            adminUser, // Admin user
            login,
            register,
            logout,
            loading,
            isAuthenticated: !!user,
            isAdminAuthenticated: !!adminUser
        }}>
            {!loading && children}
        </AuthContext.Provider>
    );
};

export const useAuth = () => useContext(AuthContext);
