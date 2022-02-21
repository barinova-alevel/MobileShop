import { inject, injectable } from "inversify";
import { makeAutoObservable, runInAction } from "mobx";
import { types } from "../../../ioc";
import { Brand } from "../models/brand";
import MobileService from "../services/MobileService";

@injectable()
export default class BrandsStore {
    brands: Brand[] = [];
    isLoading = false;

    @inject(types.mobileService)
    private readonly mobileService!: MobileService;
    constructor() {
        makeAutoObservable(this);
    }

    public init = async () => {
        this.isLoading = true;

        try {
            const brands = await this.mobileService.getBrands();
            runInAction(() => this.brands = brands)
        } catch (e) {
            if (e instanceof Error) {
                console.error(e.message);
            }
        }

        runInAction(() => this.isLoading = false);
    }
}
