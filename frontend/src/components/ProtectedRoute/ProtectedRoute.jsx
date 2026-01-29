import React from 'react';
import { Navigate, Outlet } from 'react-router-dom';
import { useAuth } from '../../contexts/AuthContext';

const ProtectedRoute = ({ allowedRoles }) => {
    const { user, isAuthenticated } = useAuth();

    if (!isAuthenticated) {
        return <Navigate to="/login" replace />;
    }

    if (allowedRoles && !allowedRoles.includes(user.role)) {
        // Redirect to dashboard if role is not authorized or show unauthorized page
        // For now, redirect to login which effectively logs them out of this restricted context
        // or just redirect to admin root
        return <Navigate to="/admin/products" replace />;
    }

    return <Outlet />;
};

export default ProtectedRoute;
