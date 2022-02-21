import { useEffect } from 'react'
import { Spinner } from '../../../components/Spinner'
import { types, useInjection } from '../../../ioc'
import { IAuthService } from '../AuthService'

export const SilentRenew = () => {
  const authService = useInjection<IAuthService>(types.authService)

  useEffect(() => {
    authService.signinSilentCallback()
  }, [authService])

  return <Spinner />
}