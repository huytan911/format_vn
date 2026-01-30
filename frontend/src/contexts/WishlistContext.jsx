import React, { createContext, useContext, useState, useEffect } from 'react';
import api from '../services/api';
import { useAuth } from './AuthContext';

const WishlistContext = createContext();

export const useWishlist = () => useContext(WishlistContext);

export const WishlistProvider = ({ children }) => {
    const [wishlistItems, setWishlistItems] = useState([]);
    const [isLoading, setIsLoading] = useState(false);
    const { isAuthenticated, user } = useAuth();

    useEffect(() => {
        if (isAuthenticated && user?.role === 'Customer') {
            fetchWishlist();
        } else {
            setWishlistItems([]);
        }
    }, [isAuthenticated, user]);

    const fetchWishlist = async () => {
        setIsLoading(true);
        try {
            const response = await api.get('/wishlist');
            setWishlistItems(response.data);
        } catch (error) {
            console.error('Error fetching wishlist:', error);
        } finally {
            setIsLoading(false);
        }
    };

    const addToWishlist = async (productId) => {
        if (!isAuthenticated) return { success: false, message: 'Please login to add to wishlist' };

        try {
            const response = await api.post('/wishlist', { productId });
            setWishlistItems(prev => [...prev, response.data]);
            return { success: true };
        } catch (error) {
            console.error('Error adding to wishlist:', error);
            return { success: false, message: error.response?.data?.message || 'Failed to add to wishlist' };
        }
    };

    const removeFromWishlist = async (productId) => {
        try {
            await api.delete(`/wishlist/${productId}`);
            setWishlistItems(prev => prev.filter(item => item.productId !== productId));
            return { success: true };
        } catch (error) {
            console.error('Error removing from wishlist:', error);
            return { success: false, message: 'Failed to remove from wishlist' };
        }
    };

    const isInWishlist = (productId) => {
        return wishlistItems.some(item => item.productId === productId);
    };

    return (
        <WishlistContext.Provider value={{
            wishlistItems,
            isLoading,
            addToWishlist,
            removeFromWishlist,
            isInWishlist,
            wishlistCount: wishlistItems.length
        }}>
            {children}
        </WishlistContext.Provider>
    );
};
