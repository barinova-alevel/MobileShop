import { useEffect } from 'react'
import { Spinner } from '../../../components/Spinner'
import { types, useInjection } from '../../../ioc'
import { IAuthService } from '../AuthService'

export const LogoutCallback = () => {
  const authService = useInjection<IAuthService>(types.authService)

  useEffect(() => {
    authService.signoutRedirectCallback()
  }, [authService])

  return <Spinner />;
}