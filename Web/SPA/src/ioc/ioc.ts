import { Container } from 'inversify';
import type { AuthenticationService} from '../services/AuthService';
import BaseAuthenticationService from '../services/AuthService';
import HomePageStore from '../stores/HomePageStore'
import LoginStore from '../stores/LoginStore'
import ownTypes from './ownTypes';
import BasketStore from '../stores/BasketStore';
import { registerMobile } from '../mobile/ioc';
import { registerLaptop } from '../laptop/ioc';

export const container = new Container();
container.bind<AuthenticationService>(ownTypes.authenticationService).to(BaseAuthenticationService).inSingletonScope();
container.bind<HomePageStore>(ownTypes.homePageStore).to(HomePageStore).inTransientScope();
container.bind<LoginStore>(ownTypes.loginStore).to(LoginStore).inSingletonScope();
container.bind<BasketStore>(ownTypes.basketStore).to(BasketStore).inSingletonScope();

registerMobile(container);
registerLaptop(container);