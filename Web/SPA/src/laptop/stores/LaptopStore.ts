import { inject, injectable } from "inversify";
import { action, makeObservable, observable, runInAction } from "mobx";
import { types } from "../../ioc";
import { Laptop } from "../models/laptop";
import LaptopService from "../services/LaptopService";

@injectable()
export default class LaptopStore {
    @observable laptop: Laptop | null = null;
    @observable isLoading = false;

    @inject(types.laptopService) 
    private readonly laptopService!: LaptopService
    constructor() {
        makeObservable(this);
    }

    @action
    public init = async (id: number) => {
        try {
            this.isLoading = true;
            const result = await this.laptopService.getById(id);
            runInAction(() => {
                this.laptop = result;
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
