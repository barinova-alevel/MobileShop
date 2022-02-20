import { inject, injectable } from "inversify"
import { makeAutoObservable } from "mobx"
import { User } from "oidc-client"
import { types } from "../ioc"
import { IAuthService } from "../services/AuthService"

@injectable()
export class AuthStore {

  @inject(types.authService)
  private readonly _authService!: IAuthService
  public user: User | null = null

  constructor() {
    makeAutoObservable(this)
  }

  public getUser = async () => {
    const userRes = await this._authService.getUser()
    this.setUser(userRes)
  }

  public setUser = (user: any) => {
    this.user = user
  }

  get isUserLoggedIn() {
    return this.user != null;
  }
}
