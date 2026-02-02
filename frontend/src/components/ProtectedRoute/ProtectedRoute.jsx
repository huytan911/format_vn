import React from 'react';
import { Navigate, Outlet } from 'react-router-dom';
import { useAuth } from '../../contexts/AuthContext';

const ProtectedRoute = ({ allowedRoles, children }) => {
    const { user, isAuthenticated } = useAuth();

    if (!isAuthenticated) {
        // If checking for Customer role (or no specific role), redirect to customer login
        if (allowedRoles && allowedRoles.includes('Customer')) {
            return <Navigate to="/login" replace />;
        }
        return <Navigate to="/admin/login" replace />;
    }

    if (allowedRoles && !allowedRoles.includes(user.role)) {
        if (user.role === 'Customer') {
            // Customer trying to access Admin
            return <Navigate to="/" replace />; // Or 403 page
        }
        return <Navigate to="/admin/login" replace />;
    }

    return children ? children : <Outlet />;
};

export default ProtectedRoute;


