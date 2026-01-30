export const getImageUrl = (url) => {
    if (!url) return 'https://via.placeholder.com/400x500?text=Format';
    if (url.startsWith('http')) return url;
    if (url.startsWith('data:')) return url;

    // For uploaded files (relative paths like /uploads/...)
    const API_BASE_URL = 'http://localhost:5149';
    return `${API_BASE_URL}${url}`;
};
