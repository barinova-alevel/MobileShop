import { Container } from "inversify";
import { types } from "../../ioc";
import { AuthService, IAuthService } from "./AuthService";
import { AuthStore } from "./AuthStore";

export function registerAuth(container: Container) {
    container.bind<IAuthService>(types.authService).to(AuthService).inSingletonScope();
    container.bind<AuthStore>(types.authStore).to(AuthStore).inSingletonScope();
}