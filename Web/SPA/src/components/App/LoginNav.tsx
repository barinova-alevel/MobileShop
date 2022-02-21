import { observer } from "mobx-react-lite";
import { useCallback } from "react";
import { NavLink } from "react-bootstrap";
import { IAuthService } from "../../modules/auth/AuthService";
import { AuthStore } from "../../modules/auth/AuthStore";
import { types, useInjection } from "../../ioc";

const LoginNav = observer(() => {
    const authStore = useInjection<AuthStore>(types.authStore);
    const authService = useInjection<IAuthService>(types.authService);
  
    const onLoginClick = useCallback(() => {
      authService.signinRedirect();
    }, []);
  
    const onLogoutClick = useCallback(() => {
      authService.logout();
    }, []);
  
    return !!authStore.user
      ? <NavLink onClick={onLogoutClick}>{authStore?.user.profile.name}</NavLink>
      : <NavLink onClick={onLoginClick}>Login</NavLink>
  });

  export default LoginNav;