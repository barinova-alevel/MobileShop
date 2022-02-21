import { Container } from "inversify";
import { types } from "../../ioc";
import BasketService from "./BasketService";
import BasketStore from "./BasketStore";

export function registerBasket(container: Container) {
    container.bind<BasketStore>(types.basketStore).to(BasketStore).inSingletonScope();
    container.bind<BasketService>(types.basketService).to(BasketService).inSingletonScope();
}