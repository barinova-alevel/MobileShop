import { useEffect } from 'react';
import "reflect-metadata";
import { Badge, Container, Nav, Navbar, NavbarBrand, NavLink } from 'react-bootstrap';
import { BrowserRouter, Outlet, Route, Routes } from 'react-router-dom';
import Catalog from './containers/Catalog';
import 'bootstrap/dist/css/bootstrap.min.css';
import "bootstrap-icons/font/bootstrap-icons.css";
import ProductDetails from './components/ProductDetails';
import Login from './pages/Login';
import LoginStore from './stores/LoginStore';
import ownTypes from './ioc/ownTypes';
import { types, useInjection } from './ioc';
import { observer } from 'mobx-react-lite';
import Basket from './components/Basket';
import BasketStore from './stores/BasketStore';
import { LinkContainer } from 'react-router-bootstrap'
import logo from './images/icon.png'
import './App.css'
import './locales/config';
import { Icon } from './components/Utils';
import MobileList from './mobile/MobileList';
import LaptopList from './laptop/LaptopList';

function App() {
  const loginStore = useInjection<LoginStore>(ownTypes.loginStore);
  const basketStore = useInjection<BasketStore>(ownTypes.basketStore);
  useEffect(() => {
    loginStore.restoreUser();
    basketStore.restoreBasket();
  }, [])

  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Layout />} >
          <Route path="" element={<MobileList />} />
          <Route path="product/:id" element={<ProductDetails />} />
          <Route path="basket" element={<Basket />} />
          <Route path="mobile" element={<MobileList />} />
          <Route path="laptop" element={<LaptopList />} />
          <Route path="login" element={<Login />} />
        </Route>
      </Routes>
    </BrowserRouter>
  );
}

function Layout() {
  return (
    <div>
      <header>
        <Navbar fixed='top' variant='light' className="bg-light" expand="sm">
          <Container>
            <LinkContainer to='/'>
              <NavbarBrand>
                <img
                  src={logo}
                  width="30"
                  height="30"
                  className="d-inline-block align-top" alt="" />
                Devices
              </NavbarBrand>
            </LinkContainer>
            <Navbar.Toggle aria-controls="basic-navbar-nav" />
            <Navbar.Collapse id="basic-navbar-nav">
              <Nav className="me-auto">
                <LinkContainer to="/">
                  <NavLink>Catalog</NavLink>
                </LinkContainer>
              </Nav>
              <Nav className="me-auto">
                <LinkContainer to="/mobile">
                  <NavLink>Mobile</NavLink>
                </LinkContainer>
              </Nav>
              <Nav className="me-auto">
                <LinkContainer to="/laptop">
                  <NavLink>Laptop</NavLink>
                </LinkContainer>
              </Nav>
              <Nav className="justify-content-end">
                <LinkContainer to='/basket'>
                  <NavLink>
                    <BasketIcon />
                  </NavLink>
                </LinkContainer>
                <LoginNav />
              </Nav>
            </Navbar.Collapse>
          </Container>
        </Navbar>
      </header>
      <main role="main">
        <Outlet />
      </main>
    </div >
  );
}

const BasketIcon = observer(() => {
  const store = useInjection<BasketStore>(types.basketStore)
  return <div>
    <Icon name="basket" size={20} />
    {
      !!store.totalCount && <Badge className="small-badge" bg="dark" pill>{store.totalCount}</Badge>
    }
  </div>
});

const LoginNav = observer(() => {
  const store = useInjection<LoginStore>(types.loginStore)
  return <LinkContainer to="/login">
    <NavLink>{store.user ? `Hello, ${store.user.firstName}` : "Login"}</NavLink>
  </LinkContainer>
})

export default App;
