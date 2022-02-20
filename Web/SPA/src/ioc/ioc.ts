import { Container } from 'inversify';
import { AuthService, IAuthService } from '../services/AuthService';
import HomePageStore from '../stores/HomePageStore'
import ownTypes from './ownTypes';
import BasketStore from '../stores/BasketStore';
import { registerMobile } from '../mobile/ioc';
import { registerLaptop } from '../laptop/ioc';
import { AuthStore } from '../stores/AuthStore';
import HttpService, { IHttpService } from '../services/HttpService';

export const container = new Container();
container.bind<IAuthService>(ownTypes.authService).to(AuthService).inSingletonScope();
container.bind<AuthStore>(ownTypes.authStore).to(AuthStore).inSingletonScope();
container.bind<IHttpService>(ownTypes.httpService).to(HttpService).inSingletonScope();
container.bind<HomePageStore>(ownTypes.homePageStore).to(HomePageStore).inTransientScope();
container.bind<BasketStore>(ownTypes.basketStore).to(BasketStore).inSingletonScope();

registerMobile(container);
registerLaptop(container);