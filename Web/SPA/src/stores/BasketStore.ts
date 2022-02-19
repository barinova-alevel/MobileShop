import { inject, injectable } from "inversify";
import { action, autorun, makeAutoObservable } from "mobx";
import { types } from "../ioc";
import { Product } from "../models/Product";
import CatalogService from "../services/CatalogService";

export interface BasketItem {
    product: Product;
    count: number;
}

type BasketModel = {
    id: number;
    count: number;
}[]

@injectable()
export default class BasketStore {
    readonly basketKey: string = "basket_items";
    basket: BasketItem[] = []

    private _initialized = false;

    @inject(types.catalogService)
    private readonly catalogService!: CatalogService;

    constructor() {
        makeAutoObservable(this);
        autorun(() => {
            if (this._initialized) {
                this.saveBasket()
            }
        })
    }

    @action
    public addToBasket = (product: Product) => {
        const basketItem = this.basket.find(_ => _.product.id == product.id)
        if (basketItem == null) {
            this.basket.push({ product: product, count: 1 })
        } else {
            basketItem.count += 1
        };
    }

    @action
    public removeFromBasket = (product: Product) => {
        this.basket = this.basket.filter(_ => _.product.id !== product.id)
    }

    @action
    public updateCount = (productId: number, changedNumber: number) => {
        const basketItem = this.basket.find(_ => _.product.id == productId);
        if (basketItem !== undefined) {
            basketItem.count = changedNumber
        }
    }

    @action
    public restoreBasket = async () => {
        const basketStr = localStorage.getItem(this.basketKey)
        if (!basketStr) return

        const basketItems: BasketModel = JSON.parse(basketStr)
        const products = await this.catalogService.getByIds(basketItems.map(_ => _.id));

        this.basket = products.map(_ => ({
            product: _,
            count: basketItems.find(i => i.count)?.count || 0
        }))
        this._initialized = true
    }

    @action
    public saveBasket = () => {
        const basketItems: BasketModel = this.basket.map((basketItem) => ({
            id: basketItem.product.id,
            count: basketItem.count
        }))
        localStorage.setItem(this.basketKey, JSON.stringify(basketItems))
    }

    @action
    public makeOrder = () => {
       localStorage.removeItem(this.basketKey)
       this.basket = []
    }

    public isInBasket = (product: Product) => {
        return this.basket.find(_ => _.product.id == product.id);
    }

    get totalCount() {
        return this.basket.reduce((c, i) => c + i.count, 0)
    }
    get totalPrice() {
        return this.basket.reduce((c, i) => c + i.product.price * i.count, 0)
    }
}