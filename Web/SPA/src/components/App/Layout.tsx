import { Container, Nav, Navbar, NavbarBrand, NavLink } from 'react-bootstrap';
import { Outlet } from 'react-router-dom';
import { LinkContainer } from 'react-router-bootstrap'
import logo from '../../images/icon.png'
import { BasketIcon } from '../../modules/basket/components';
import LoginNav from './LoginNav';

const Layout = () => {
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

  export default Layout;