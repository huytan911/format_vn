import React, { createContext, useContext, useState, useEffect } from 'react';
import api from '../services/api';
import { useAuth } from './AuthContext';

const CartContext = createContext();

export const useCart = () => useContext(CartContext);

export const CartProvider = ({ children }) => {
    const [cartItems, setCartItems] = useState([]);
    const [isLoading, setIsLoading] = useState(false);
    const { isAuthenticated, user } = useAuth();

    // Load from localStorage on mount (for Guest)
    useEffect(() => {
        const savedCart = localStorage.getItem('guest_cart');
        if (!isAuthenticated) {
            if (savedCart) {
                setCartItems(JSON.parse(savedCart));
            }
        }
    }, [isAuthenticated]);

    // Sync with backend on login
    useEffect(() => {
        if (isAuthenticated && user?.role === 'Customer') {
            syncAndFetchCart();
        }
    }, [isAuthenticated, user]);

    const syncAndFetchCart = async () => {
        setIsLoading(true);
        try {
            // First, get guest cart if any
            const guestCart = JSON.parse(localStorage.getItem('guest_cart') || '[]');

            // Sync each item to backend
            for (const item of guestCart) {
                await api.post('/cart', { productId: item.productId, quantity: item.quantity });
            }

            // Clear guest cart
            localStorage.removeItem('guest_cart');

            // Fetch the combined cart from backend
            const response = await api.get('/cart');
            setCartItems(response.data);
        } catch (error) {
            console.error('Error syncing/fetching cart:', error);
        } finally {
            setIsLoading(false);
        }
    };

    const addToCart = async (product, quantity = 1) => {
        if (isAuthenticated && user?.role === 'Customer') {
            try {
                const response = await api.post('/cart', { productId: product.id, quantity });
                // Re-fetch fetch all to be safe or update local state
                const fetchRes = await api.get('/cart');
                setCartItems(fetchRes.data);
                return { success: true };
            } catch (error) {
                console.error('Error adding to backend cart:', error);
                return { success: false };
            }
        } else {
            // Guest mode
            setCartItems(prev => {
                const existing = prev.find(item => item.productId === product.id);
                let newCart;
                if (existing) {
                    newCart = prev.map(item =>
                        item.productId === product.id
                            ? { ...item, quantity: item.quantity + quantity }
                            : item
                    );
                } else {
                    newCart = [...prev, {
                        id: Date.now(), // Temp ID
                        productId: product.id,
                        productName: product.name,
                        price: product.price,
                        imageUrl: product.imageUrl,
                        quantity
                    }];
                }
                localStorage.setItem('guest_cart', JSON.stringify(newCart));
                return newCart;
            });
            return { success: true };
        }
    };

    const updateQuantity = async (id, quantity) => {
        if (isAuthenticated && user?.role === 'Customer') {
            try {
                await api.put(`/cart/${id}`, { quantity });
                setCartItems(prev => {
                    if (quantity <= 0) return prev.filter(item => item.id !== id);
                    return prev.map(item => item.id === id ? { ...item, quantity } : item);
                });
            } catch (error) {
                console.error('Error updating cart quantity:', error);
            }
        } else {
            setCartItems(prev => {
                const newCart = prev.map(item => item.id === id ? { ...item, quantity } : item)
                    .filter(item => item.quantity > 0);
                localStorage.setItem('guest_cart', JSON.stringify(newCart));
                return newCart;
            });
        }
    };

    const removeFromCart = async (id) => {
        if (isAuthenticated && user?.role === 'Customer') {
            try {
                await api.delete(`/cart/${id}`);
                setCartItems(prev => prev.filter(item => item.id !== id));
            } catch (error) {
                console.error('Error removing from cart:', error);
            }
        } else {
            setCartItems(prev => {
                const newCart = prev.filter(item => item.id !== id);
                localStorage.setItem('guest_cart', JSON.stringify(newCart));
                return newCart;
            });
        }
    };

    const clearCart = async () => {
        if (isAuthenticated && user?.role === 'Customer') {
            try {
                await api.delete('/cart/clear');
                setCartItems([]);
            } catch (error) {
                console.error('Error clearing cart:', error);
            }
        } else {
            localStorage.removeItem('guest_cart');
            setCartItems([]);
        }
    };

    const cartTotal = cartItems.reduce((sum, item) => sum + (item.price * item.quantity), 0);
    const cartCount = cartItems.reduce((sum, item) => sum + item.quantity, 0);

    return (
        <CartContext.Provider value={{
            cartItems,
            isLoading,
            addToCart,
            updateQuantity,
            removeFromCart,
            clearCart,
            cartTotal,
            cartCount
        }}>
            {children}
        </CartContext.Provider>
    );
};
