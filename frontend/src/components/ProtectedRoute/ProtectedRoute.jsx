import React from 'react';
import { Navigate, Outlet } from 'react-router-dom';
import { useAuth } from '../../contexts/AuthContext';

const ProtectedRoute = ({ allowedRoles, children }) => {
    const { user, adminUser, isAuthenticated, isAdminAuthenticated } = useAuth();

    // Check if the route is intended for Customers
    const isCustomerRoute = allowedRoles && allowedRoles.includes('Customer');

    if (isCustomerRoute) {
        if (!isAuthenticated) {
            return <Navigate to="/login" replace />;
        }
        // If logged in but somehow not a customer (shouldn't happen with current logic as user is only customer), check role anyway
        if (allowedRoles && !allowedRoles.includes(user.role)) {
            return <Navigate to="/" replace />;
        }
        return children ? children : <Outlet />;
    }

    // Otherwise, assume it's an Admin route
    if (!isAdminAuthenticated) {
        return <Navigate to="/admin/login" replace />;
    }

    if (allowedRoles && !allowedRoles.includes(adminUser?.role)) {
        return <Navigate to="/admin" replace />; // or some forbidden page
    }

    return children ? children : <Outlet />;
};

export default ProtectedRoute;


