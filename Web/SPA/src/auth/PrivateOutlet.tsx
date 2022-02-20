import { Outlet } from 'react-router-dom'
import { observer } from 'mobx-react-lite'
import { IAuthService } from '../services/AuthService'
import { types, useInjection } from '../ioc'

const PrivateOutlet = observer(() => {
  const authService = useInjection<IAuthService>(types.authService)

  if (!authService.isAuthenticated()) {
    authService.signinRedirect()
    return <>Loading...</>
  }

  return <Outlet/>
})

export default PrivateOutlet
