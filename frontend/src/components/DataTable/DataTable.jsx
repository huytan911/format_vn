import React, { useState } from 'react';
import './DataTable.css';

const DataTable = ({ columns, data, onEdit, onDelete, onView }) => {
    const [searchTerm, setSearchTerm] = useState('');
    const [currentPage, setCurrentPage] = useState(1);
    const [sortConfig, setSortConfig] = useState({ key: null, direction: 'asc' });
    const itemsPerPage = 10;

    // Filter data based on search term
    const filteredData = data.filter(item =>
        columns.some(column => {
            const value = column.accessor.split('.').reduce((obj, key) => obj?.[key], item);
            return value?.toString().toLowerCase().includes(searchTerm.toLowerCase());
        })
    );

    // Sort data
    const sortedData = [...filteredData].sort((a, b) => {
        if (!sortConfig.key) return 0;

        const aValue = sortConfig.key.split('.').reduce((obj, key) => obj?.[key], a);
        const bValue = sortConfig.key.split('.').reduce((obj, key) => obj?.[key], b);

        if (aValue < bValue) return sortConfig.direction === 'asc' ? -1 : 1;
        if (aValue > bValue) return sortConfig.direction === 'asc' ? 1 : -1;
        return 0;
    });

    // Pagination
    const totalPages = Math.ceil(sortedData.length / itemsPerPage);
    const startIndex = (currentPage - 1) * itemsPerPage;
    const paginatedData = sortedData.slice(startIndex, startIndex + itemsPerPage);

    const handleSort = (key) => {
        setSortConfig({
            key,
            direction: sortConfig.key === key && sortConfig.direction === 'asc' ? 'desc' : 'asc'
        });
    };

    return (
        <div className="datatable-container">
            <div className="datatable-controls">
                <input
                    type="text"
                    placeholder="Tìm kiếm..."
                    value={searchTerm}
                    onChange={(e) => setSearchTerm(e.target.value)}
                    className="search-input"
                />
                <div className="results-count">
                    Hiển thị {paginatedData.length} / {filteredData.length} kết quả
                </div>
            </div>

            <div className="table-wrapper">
                <table className="data-table">
                    <thead>
                        <tr>
                            {columns.map(column => (
                                <th
                                    key={column.accessor}
                                    onClick={() => column.sortable && handleSort(column.accessor)}
                                    className={`${column.sortable ? 'sortable' : ''} ${sortConfig.key === column.accessor ? 'active-sort' : ''}`}
                                >
                                    <div className="th-content">
                                        {column.header}
                                        {column.sortable && (
                                            <span className={`sort-icon ${sortConfig.key === column.accessor ? 'visible' : ''}`}>
                                                {sortConfig.key === column.accessor && sortConfig.direction === 'desc' ? ' ▼' : ' ▲'}
                                            </span>
                                        )}
                                    </div>
                                </th>
                            ))}
                            <th className="actions-column">Thao tác</th>
                        </tr>
                    </thead>
                    <tbody>
                        {paginatedData.length === 0 ? (
                            <tr>
                                <td colSpan={columns.length + 1} className="no-data">
                                    Không có dữ liệu
                                </td>
                            </tr>
                        ) : (
                            paginatedData.map((item, index) => (
                                <tr key={item.id || index}>
                                    {columns.map(column => (
                                        <td key={column.accessor}>
                                            {column.render
                                                ? column.render(item)
                                                : column.accessor.split('.').reduce((obj, key) => obj?.[key], item)}
                                        </td>
                                    ))}
                                    <td className="actions-cell">
                                        {onView && (
                                            <button
                                                className="btn-action btn-view"
                                                onClick={() => onView(item)}
                                                title="Xem chi tiết"
                                            >
                                                👁
                                            </button>
                                        )}
                                        {onEdit && (
                                            <button
                                                className="btn-action btn-edit"
                                                onClick={() => onEdit(item)}
                                                title="Chỉnh sửa"
                                            >
                                                ✏️
                                            </button>
                                        )}
                                        {onDelete && (
                                            <button
                                                className="btn-action btn-delete"
                                                onClick={() => onDelete(item)}
                                                title="Xóa"
                                            >
                                                🗑️
                                            </button>
                                        )}
                                    </td>
                                </tr>
                            ))
                        )}
                    </tbody>
                </table>
            </div>

            {totalPages > 1 && (
                <div className="pagination">
                    <button
                        onClick={() => setCurrentPage(p => Math.max(1, p - 1))}
                        disabled={currentPage === 1}
                        className="pagination-btn"
                    >
                        ← Trước
                    </button>
                    <span className="pagination-info">
                        Trang {currentPage} / {totalPages}
                    </span>
                    <button
                        onClick={() => setCurrentPage(p => Math.min(totalPages, p + 1))}
                        disabled={currentPage === totalPages}
                        className="pagination-btn"
                    >
                        Sau →
                    </button>
                </div>
            )}
        </div>
    );
};

export default DataTable;
