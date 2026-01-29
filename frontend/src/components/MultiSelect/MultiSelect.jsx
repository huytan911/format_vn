import React, { useState, useEffect, useRef } from 'react';
import './MultiSelect.css';

const MultiSelect = ({ options, selectedIds, onChange, placeholder = 'Select items...' }) => {
    const [isOpen, setIsOpen] = useState(false);
    const [searchTerm, setSearchTerm] = useState('');
    const dropdownRef = useRef(null);

    // Close dropdown when clicking outside
    useEffect(() => {
        const handleClickOutside = (event) => {
            if (dropdownRef.current && !dropdownRef.current.contains(event.target)) {
                setIsOpen(false);
            }
        };

        document.addEventListener('mousedown', handleClickOutside);
        return () => {
            document.removeEventListener('mousedown', handleClickOutside);
        };
    }, []);

    const filteredOptions = options.filter(option =>
        option.name.toLowerCase().includes(searchTerm.toLowerCase())
    );

    const handleToggle = () => setIsOpen(!isOpen);

    const handleOptionClick = (id) => {
        let newSelectedIds;
        if (selectedIds.includes(id)) {
            newSelectedIds = selectedIds.filter(itemId => itemId !== id);
        } else {
            newSelectedIds = [...selectedIds, id];
        }
        onChange(newSelectedIds);
    };

    const handleRemoveTag = (e, id) => {
        e.stopPropagation(); // Prevent dropdown toggle
        const newSelectedIds = selectedIds.filter(itemId => itemId !== id);
        onChange(newSelectedIds);
    };

    const getSelectedNames = () => {
        return options
            .filter(opt => selectedIds.includes(opt.id))
            .map(opt => opt.name);
    };

    const selectedNames = getSelectedNames();

    return (
        <div className="multi-select-container" ref={dropdownRef}>
            <div className={`multi-select-trigger ${isOpen ? 'open' : ''}`} onClick={handleToggle}>
                <div className="selected-tags">
                    {selectedIds.length > 0 ? (
                        selectedNames.map((name, index) => {
                            // Find id for this name
                            const id = options.find(o => o.name === name)?.id;
                            return (
                                <span key={index} className="tag">
                                    {name}
                                    <span className="remove-tag" onClick={(e) => handleRemoveTag(e, id)}>×</span>
                                </span>
                            );
                        })
                    ) : (
                        <span className="placeholder">{placeholder}</span>
                    )}
                </div>
                <div className="arrow">▼</div>
            </div>

            {isOpen && (
                <div className="multi-select-dropdown">
                    <div className="search-container">
                        <input
                            type="text"
                            placeholder="Search..."
                            value={searchTerm}
                            onChange={(e) => setSearchTerm(e.target.value)}
                            onClick={(e) => e.stopPropagation()}
                            autoFocus
                        />
                    </div>
                    <ul className="options-list">
                        {filteredOptions.length > 0 ? (
                            filteredOptions.map(option => (
                                <li
                                    key={option.id}
                                    className={`option ${selectedIds.includes(option.id) ? 'selected' : ''}`}
                                    onClick={() => handleOptionClick(option.id)}
                                >
                                    <input
                                        type="checkbox"
                                        checked={selectedIds.includes(option.id)}
                                        readOnly
                                    />
                                    <span>{option.name}</span>
                                </li>
                            ))
                        ) : (
                            <li className="no-options">No options found</li>
                        )}
                    </ul>
                </div>
            )}
        </div>
    );
};

export default MultiSelect;
