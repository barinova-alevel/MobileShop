import { useEffect } from 'react'
import { types, useInjection } from '../ioc'
import { IAuthService } from '../services/AuthService'

export const Callback = () => {
  const authService = useInjection<IAuthService>(types.authService)

  useEffect(() => {
    authService.signinRedirectCallback()
  }, [authService])

  return <>Loading...</>
}