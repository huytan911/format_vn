import React from 'react';
import { useToast } from '../../contexts/ToastContext';
import { FiCheckCircle, FiXCircle, FiInfo, FiX } from 'react-icons/fi';
import './Toast.css';

const ToastContainer = () => {
    const { toasts, removeToast } = useToast();

    if (toasts.length === 0) return null;

    return (
        <div className="toast-container">
            {toasts.map((toast) => (
                <div key={toast.id} className={`toast toast-${toast.type}`}>
                    <div className="toast-icon">
                        {toast.type === 'success' && <FiCheckCircle />}
                        {toast.type === 'error' && <FiXCircle />}
                        {toast.type === 'info' && <FiInfo />}
                    </div>
                    <div className="toast-message">{toast.message}</div>
                    <button className="toast-close" onClick={() => removeToast(toast.id)}>
                        <FiX />
                    </button>
                </div>
            ))}
        </div>
    );
};

export default ToastContainer;
