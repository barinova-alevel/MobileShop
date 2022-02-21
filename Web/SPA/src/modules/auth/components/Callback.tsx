import { useEffect } from 'react'
import { Spinner } from '../../../components/Spinner'
import { types, useInjection } from '../../../ioc'
import { IAuthService } from '../AuthService'

export const Callback = () => {
  const authService = useInjection<IAuthService>(types.authService)

  useEffect(() => {
    if (!authService.isAuthenticated()) {
      authService.signinRedirectCallback();
    } else {
      authService.navigateToHome();
    }
  }, [authService])

  return <Spinner />;
}