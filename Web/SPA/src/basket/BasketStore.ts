import { inject, injectable } from "inversify";
import { action, autorun, makeAutoObservable, toJS } from "mobx";
import { types } from "../ioc";
import { Device } from "../models/Device";
import BasketService from "./BasketService";
import { Basket } from "./models/basket";
import { BasketItem } from "./models/basketItem";

const EMPTY_BASKET: Basket = { items: [], totalPrice: 0, totalQuantity: 0 };

@injectable()
export default class BasketStore {
    basket: Basket = EMPTY_BASKET;
    isLoading: boolean = false;

    @inject(types.basketService)
    private readonly basketService!: BasketService

    constructor() {
        makeAutoObservable(this);
    }

    @action
    public addToBasket = async (device: Device) => {
        const items = toJS(this.basket.items);
        const basketItem = items.find(_ => _.sku == device.sku)
        if (basketItem == null) {
            items.push({ ...device, deviceName: device.name, quantity: 1 })
        } else {
            basketItem.quantity += 1;
        };

        await this.setBasket(items);
    }

    @action
    public removeFromBasket = async (sku: string) => {
        const items = this.basket.items.filter(_ => _.sku !== sku);
        await this.setBasket(toJS(items));
    }

    @action
    public updateCount = (sku: string, changedNumber: number) => {
        const items = toJS(this.basket.items);
        const item = items.find(_ => _.sku == sku);
        if (item == undefined) {
            return;
        }

        item.quantity = changedNumber;
        this.setBasket(items);
    }

    @action
    public getBasket = async () => {
        this.isLoading = true;

        try {
            this.basket = await this.basketService.get();
        } catch (e) {
            if (e instanceof Error) {
                console.error(e.message);
            }
        }

        this.isLoading = false;
    }

    @action
    public makeOrder = async () => {
        this.isLoading = true;

        try {
            await this.basketService.delete();
            this.basket = EMPTY_BASKET;
        } catch (e) {
            if (e instanceof Error) {
                console.error(e.message);
            }
        }

        this.isLoading = false;
    }

    public isInBasket = (product: Device) => {
        return this.basket?.items.find(_ => _.sku == product.sku);
    }

    private setBasket = async (items: BasketItem[]) => {
        this.isLoading = true;

        try {
            this.basket = await this.basketService.set(items);

        } catch (e) {
            if (e instanceof Error) {
                console.error(e.message);
            }
        }

        this.isLoading = false;
    }
}