import { Outlet } from 'react-router-dom'
import { observer } from 'mobx-react-lite'
import { IAuthService } from '../AuthService'
import { types, useInjection } from '../../../ioc'
import { Spinner } from '../../../components/Spinner'

export const PrivateOutlet = observer(() => {
  const authService = useInjection<IAuthService>(types.authService)
  if (!authService.isAuthenticated()) {
    authService.signinRedirect()
    return <Spinner />;
  }

  return <Outlet />
})
