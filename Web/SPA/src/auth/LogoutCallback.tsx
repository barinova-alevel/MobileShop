import { useEffect } from 'react'
import { types, useInjection } from '../ioc'
import { IAuthService } from '../services/AuthService'

export const LogoutCallback = () => {
  const authService = useInjection<IAuthService>(types.authService)

  useEffect(() => {
    authService.signoutRedirectCallback()
  }, [authService])

  return <>Loading...</>
}