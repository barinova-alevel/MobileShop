import { inject, injectable } from "inversify";
import { makeAutoObservable, runInAction } from "mobx";
import { types } from "../../../ioc";
import { Laptop } from "../models/laptop";
import LaptopService from "../services/LaptopService";

@injectable()
export default class LaptopStore {
    laptop: Laptop | null = null;
    isLoading = false;

    @inject(types.laptopService) 
    private readonly laptopService!: LaptopService
    constructor() {
        makeAutoObservable(this);
    }

    public init = async (id: number) => {
        this.isLoading = true;

        try {
            const result = await this.laptopService.getById(id);
            runInAction(() => this.laptop = result);
        } catch (e) {
            if (e instanceof Error) {
                console.error(e.message);
            }
        }

        runInAction(() => this.isLoading = false);
    }
}
