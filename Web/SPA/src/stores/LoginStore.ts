import { inject, injectable } from "inversify";
import { action, makeObservable, observable, runInAction } from "mobx";
import ownTypes from "../ioc/ownTypes";
import { User } from "../models/User";
import type AuthenticationService from "../services/AuthService";

@injectable()
export default class LoginStore {

  readonly userIdKey: string = "logged_userid";
  @observable isLoading = false;
  @observable error = '';
  @observable user: User | null = null;

  @inject(ownTypes.authenticationService)
  private readonly authenticationService!: AuthenticationService
  constructor() {
    makeObservable(this);
  }

  @action restoreUser = async () => {
    const userId = localStorage.getItem(this.userIdKey);
    if (userId) {
      this.user = await this.authenticationService.getUserById(userId)
    }
  }

  @action
  public login = async (email: string, password: string) => {
    this.error = '';
    this.user = null;
    try {
      this.isLoading = true;
      const result = await this.authenticationService.login(email, password);
      this.user = result;
      localStorage.setItem(this.userIdKey, result.id);
    } catch (e) {
      if (e instanceof Error) {
        this.error = e.message;
      }
    }
    this.isLoading = false;
  }

  @action
  public logOut = (): void => {
    localStorage.removeItem(this.userIdKey);
    this.user = null;
  }

  get isUserLoggedIn() {
    return this.user != null;
  }
}
