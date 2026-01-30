import { BrowserRouter as Router, Routes, Route, Navigate } from 'react-router-dom';
import { AuthProvider } from './contexts/AuthContext';
import { CartProvider } from './contexts/CartContext';
import { WishlistProvider } from './contexts/WishlistContext';
import { ToastProvider } from './contexts/ToastContext';

// Components
import ToastContainer from './components/Toast/Toast';
import ProtectedRoute from './components/ProtectedRoute/ProtectedRoute';
import Login from './pages/Login/Login';
import Header from './components/Header/Header';
import Footer from './components/Footer/Footer';
import Home from './pages/Home/Home';
import ProductList from './pages/ProductList/ProductList';
import ProductDetail from './pages/ProductDetail/ProductDetail';
import AdminProducts from './pages/Admin/AdminProducts';
import AdminCategories from './pages/Admin/AdminCategories';
import AdminCustomers from './pages/Admin/AdminCustomers';
import AdminOrders from './pages/Admin/AdminOrders';
import AdminProductEdit from './pages/Admin/AdminProductEdit';
import CustomerLogin from './pages/Auth/CustomerLogin';
import CustomerRegister from './pages/Auth/CustomerRegister';
import Profile from './pages/Customer/Profile';
import Cart from './pages/Cart/Cart';
import Wishlist from './pages/Wishlist/Wishlist';
import './App.css';

function App() {
  return (
    <Router>
      <ToastProvider>
        <AuthProvider>
          <CartProvider>
            <WishlistProvider>
              <ToastContainer />
              <Routes>
                {/* Auth Routes */}
                <Route path="/login" element={<CustomerLogin />} />
                <Route path="/register" element={<CustomerRegister />} />
                <Route path="/admin/login" element={<Login />} />
                <Route path="/admin" element={<Navigate to="/admin/products" replace />} />

                {/* Admin Routes - Protected */}
                <Route element={<ProtectedRoute />}>
                  <Route path="/admin/products" element={<AdminProducts />} />
                  <Route path="/admin/products/new" element={<AdminProductEdit />} />
                  <Route path="/admin/products/edit/:id" element={<AdminProductEdit />} />
                  <Route path="/admin/categories" element={<AdminCategories />} />
                  <Route path="/admin/customers" element={<AdminCustomers />} />
                  <Route path="/admin/orders" element={<AdminOrders />} />
                </Route>

                {/* Public Routes - with header/footer */}
                <Route path="/*" element={
                  <div className="app">
                    <Header />
                    <main className="main-content">
                      <Routes>
                        <Route path="/" element={<Home />} />
                        <Route path="/category/:categoryId" element={<ProductList />} />
                        <Route path="/products" element={<ProductList />} />
                        <Route path="/product/:id" element={<ProductDetail />} />
                        <Route path="/profile" element={<Profile />} />
                        <Route path="/cart" element={<Cart />} />
                        <Route path="/wishlist" element={<Wishlist />} />
                      </Routes>
                    </main>
                    <Footer />
                  </div>
                } />
              </Routes>
            </WishlistProvider>
          </CartProvider>
        </AuthProvider>
      </ToastProvider>
    </Router>
  );
}

export default App;
