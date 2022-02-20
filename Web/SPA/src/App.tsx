import { useEffect } from 'react';
import "reflect-metadata";
import { Badge, Container, Nav, Navbar, NavbarBrand, NavLink } from 'react-bootstrap';
import { BrowserRouter, Outlet, Route, Routes, useNavigate } from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap.min.css';
import "bootstrap-icons/font/bootstrap-icons.css";
import Login from './pages/Login';
import { types, useInjection } from './ioc';
import { observer } from 'mobx-react-lite';
import Basket from './components/Basket';
import BasketStore from './basket/BasketStore';
import { LinkContainer } from 'react-router-bootstrap'
import logo from './images/icon.png'
import './App.css'
import './locales/config';
import { Icon } from './components/Utils';
import MobileList from './mobile/components/MobileList';
import LaptopList from './laptop/components/LaptopList';
import MobileDetails from './mobile/components/MobileDetails';
import LaptopDetails from './laptop/components/LaptopDetails';
import { AuthStore } from './stores/AuthStore';
import { Callback } from './auth/Callback';
import { Logout } from './auth/Logout';
import { LogoutCallback } from './auth/LogoutCallback';
import { SilentRenew } from './auth/SilentRenew';
import PrivateOutlet from './auth/PrivateOutlet';

function App() {
  const loginStore = useInjection<AuthStore>(types.authStore);
  const basketStore = useInjection<BasketStore>(types.basketStore);
  useEffect(() => {
    loginStore.getUser();
    basketStore.getBasket();
  }, [])

  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Layout />} >
          <Route path="" element={<MobileList />} />
          <Route path="mobile" element={<MobileList />} />
          <Route path="mobile/:id" element={<MobileDetails />} />
          <Route path="laptop" element={<LaptopList />} />
          <Route path="laptop/:id" element={<LaptopDetails />} />

          <Route path="/signin-oidc" element={<Callback />} />
          <Route path="/logout" element={<Logout />} />
          <Route path="/logout/callback" element={<LogoutCallback />} />
          <Route path="/silentrenew" element={<SilentRenew />} />
          <Route element={<PrivateOutlet />}>
            <Route path="/login" element={<Login />} />
            <Route path="basket" element={<Basket />} />
          </Route>
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
              <Nav>
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
      !!store.basket.totalQuantity && <Badge
        className="small-badge"
        bg="dark" pill>
        {store.basket.totalQuantity}
      </Badge>
    }
  </div>
});

const LoginNav = observer(() => {
  const authStore = useInjection<AuthStore>(types.authStore);
  return !!authStore.user
    ? <LinkContainer to="/logout">
      <NavLink>{authStore?.user?.profile?.name}</NavLink>
    </LinkContainer>
    : <LinkContainer to="/login">
      <NavLink>Login</NavLink>
    </LinkContainer>
});

export default App;
