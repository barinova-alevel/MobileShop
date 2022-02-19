import { inject, injectable } from "inversify";
import { action, makeObservable, observable } from "mobx";
import { types } from "../../ioc";
import { ScreenType } from "../models/screenType";
import LaptopService from "../services/LaptopService";

@injectable()
export default class ScreenTypesStore {
    @observable screenTypes: ScreenType[] = [];
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
            this.screenTypes = await this.laptopService.getScreenTypes();
        } catch (e) {
            if (e instanceof Error) {
                console.error(e.message);
            }
        }

        this.isLoading = false;
    }
}