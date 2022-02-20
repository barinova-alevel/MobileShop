import { useEffect } from 'react'
import { types, useInjection } from '../ioc'
import { IAuthService } from '../services/AuthService'

export const Logout = () => {
  const authService = useInjection<IAuthService>(types.authService)

  useEffect(() => {
    authService.logout()
  }, [authService])

  return <>Loading...</>
} 