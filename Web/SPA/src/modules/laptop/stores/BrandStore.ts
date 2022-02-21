import { inject, injectable } from "inversify";
import { makeAutoObservable, runInAction } from "mobx";
import { types } from "../../../ioc";
import { Brand } from "../models/brand";
import LaptopService from "../services/LaptopService";

@injectable()
export default class BrandStore {
    brands: Brand[] = [];
    isLoading = false;

    @inject(types.laptopService)
    private readonly laptopService!: LaptopService;
    constructor() {
        makeAutoObservable(this);
    }

    public init = async () => {
        this.isLoading = true;

        try {
            const brands = await this.laptopService.getBrands();
            runInAction(() => this.brands = brands);
        } catch (e) {
            if (e instanceof Error) {
                console.error(e.message);
            }
        }

        runInAction(() => this.isLoading = false);
    }
}