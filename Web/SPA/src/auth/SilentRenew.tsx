import { useEffect } from 'react'
import { types, useInjection } from '../ioc'
import { IAuthService } from '../services/AuthService'

export const SilentRenew = () => {
  const authService = useInjection<IAuthService>(types.authService)

  useEffect(() => {
    authService.signinSilentCallback()
  }, [authService])

  return <>Loading...</>
}