import { injectable } from 'inversify'
import 'reflect-metadata'
import { UserManager, Log, User } from 'oidc-client'
import { AuthConst } from '../utils/authConst'

export interface IAuthService {
  signinRedirectCallback: () => void,
  logout: () => void,
  signoutRedirectCallback: () => void,
  isAuthenticated: () => ({}),
  signinRedirect: () => void,
  signinSilentCallback: () => void,
  createSigninRequest: () => ({}),
  getUser: () => Promise<User | null>
}

@injectable()
export class AuthService implements IAuthService {
  private readonly _userManager

  constructor () {
    this._userManager = new UserManager(AuthConst)

    Log.logger = console
    Log.level = Log.DEBUG
  }

  signinRedirectCallback = () => {
    this._userManager.signinRedirectCallback().then(() => {
      this.navigateToScreen()
    })
  }

  getUser = async () => {
    return await this._userManager.getUser()
  }

  parseJwt = (token: string) => {
    const base64Url = token.split('.')[1]
    const base64 = base64Url.replace('-', '+').replace('_', '/')
    return JSON.parse(window.atob(base64))
  }

  signinRedirect = () => {
    localStorage.setItem('redirectUri', window.location.pathname)
    this._userManager.signinRedirect({})
  }

  navigateToScreen = () => {
    window.location.replace(localStorage.getItem('redirectUri') || '/')
  }

  isAuthenticated = () => {
    const oidcStorage = JSON.parse(String(sessionStorage.getItem(`oidc.user:${process.env.REACT_APP_AUTH_URL}:${process.env.REACT_APP_IDENTITY_CLIENT_ID}`)))

    return (!!oidcStorage && !!oidcStorage.id_token)
  }

  signinSilent = () => {
    this._userManager.signinSilent()
      .then((user) => {
        console.log('signed in', user)
      })
      .catch((err) => {
        console.log(err)
      })
  }

  signinSilentCallback = () => {
    this._userManager.signinSilentCallback()
  }

  createSigninRequest = () => {
    return this._userManager.createSigninRequest()
  }

  logout = () => {
    this._userManager.signoutRedirect({
      id_token_hint: localStorage.getItem('id_token')
    })
    this._userManager.clearStaleState()
  }

  signoutRedirectCallback = () => {
    this._userManager.signoutRedirectCallback().then(() => {
      localStorage.clear()
      window.location.replace(process.env.REACT_APP_PUBLIC_URL!)
    })
    this._userManager.clearStaleState()
  }
}