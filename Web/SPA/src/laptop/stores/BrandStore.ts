import { inject, injectable } from "inversify";
import { action, makeObservable, observable } from "mobx";
import { types } from "../../ioc";
import { Brand } from "../models/brand";
import LaptopService from "../services/LaptopService";

@injectable()
export default class BrandsStore {
    @observable brands: Brand[] = [];
    @observable isLoading = false;

    @inject(types.laptopService)
    private readonly laptopService!: LaptopService;
    constructor() {
        makeObservable(this);
    }

    @action
    public init = async () => {
        this.isLoading = true;

        try {
            this.brands = await this.laptopService.getBrands();
        } catch (e) {
            if (e instanceof Error) {
                console.error(e.message);
            }
        }

        this.isLoading = false;
    }
}