import React from 'react';
import { FiChevronLeft, FiChevronRight } from 'react-icons/fi';
import './Pagination.css';

const Pagination = ({ currentPage, totalPages, onPageChange }) => {
    if (totalPages <= 1) return null;

    const getPageNumbers = () => {
        const pages = [];
        const maxVisiblePages = 5;

        if (totalPages <= maxVisiblePages) {
            for (let i = 1; i <= totalPages; i++) pages.push(i);
        } else {
            let start = Math.max(1, currentPage - 2);
            let end = Math.min(totalPages, start + maxVisiblePages - 1);

            if (end === totalPages) {
                start = Math.max(1, end - maxVisiblePages + 1);
            }

            for (let i = start; i <= end; i++) {
                pages.push(i);
            }
        }
        return pages;
    };

    return (
        <div className="pagination-container">
            <button
                className="pagination-btn arrow"
                onClick={() => onPageChange(currentPage - 1)}
                disabled={currentPage === 1}
                aria-label="Previous Page"
            >
                <FiChevronLeft size={20} />
            </button>

            <div className="pagination-numbers">
                {getPageNumbers().map(number => (
                    <button
                        key={number}
                        className={`pagination-btn number ${currentPage === number ? 'active' : ''}`}
                        onClick={() => onPageChange(number)}
                    >
                        {number}
                    </button>
                ))}
            </div>

            <button
                className="pagination-btn arrow"
                onClick={() => onPageChange(currentPage + 1)}
                disabled={currentPage === totalPages}
                aria-label="Next Page"
            >
                <FiChevronRight size={20} />
            </button>
        </div>
    );
};

export default Pagination;
