import { inject, injectable } from "inversify";
import { action, makeObservable, observable, runInAction } from "mobx";
import ownTypes from "../ioc/ownTypes";
import type { Product } from "../models/Product";
import CatalogService from "../services/CatalogService";

@injectable()
export default class ProductStore {
    @observable product: Product | null = null;
    @observable isLoading = false;

    @inject(ownTypes.catalogService) 
    private readonly catalogService!: CatalogService
    constructor() {
        makeObservable(this);
    }

    @action
    public init = async (productId: number) => {
        try {
            this.isLoading = true;
            const result = await this.catalogService.getById(productId);
            runInAction(() => {
                this.product = result;
            });

        } catch (e) {
            if (e instanceof Error) {
                console.error(e.message);
            }
        }
        runInAction(() => {
            this.isLoading = false;
        });
    }
}
