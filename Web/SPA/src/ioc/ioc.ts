import "reflect-metadata";
import { Container } from 'inversify';
import ownTypes from './ownTypes';
import HttpService, { IHttpService } from '../services/HttpService';
import { registerMobile } from '../modules/mobile/ioc';
import { registerLaptop } from '../modules/laptop/ioc';
import { registerAuth } from '../modules/auth/ioc';
import { registerBasket } from '../modules/basket/ioc';

export const container = new Container();
container.bind<IHttpService>(ownTypes.httpService).to(HttpService).inSingletonScope();

registerAuth(container);
registerMobile(container);
registerLaptop(container);
registerBasket(container);