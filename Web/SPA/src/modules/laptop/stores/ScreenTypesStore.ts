import { inject, injectable } from "inversify";
import { makeAutoObservable, runInAction } from "mobx";
import { types } from "../../../ioc";
import { ScreenType } from "../models/screenType";
import LaptopService from "../services/LaptopService";

@injectable()
export default class ScreenTypesStore {
    screenTypes: ScreenType[] = [];
    isLoading = false;

    @inject(types.laptopService)
    private readonly laptopService!: LaptopService;
    constructor() {
        makeAutoObservable(this);
    }

    public init = async () => {
        this.isLoading = true;

        try {
            const screenTypes = await this.laptopService.getScreenTypes();
            runInAction(() => this.screenTypes = screenTypes);
        } catch (e) {
            if (e instanceof Error) {
                console.error(e.message);
            }
        }

        runInAction(() => this.isLoading = false);
    }
}