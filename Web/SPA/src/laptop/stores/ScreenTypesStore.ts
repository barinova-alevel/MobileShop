import { inject, injectable } from "inversify";
import { action, makeObservable, observable } from "mobx";
import { types } from "../../ioc";
import { ScreenType } from "../models/screenType";
import LaptopService from "../services/LaptopService";

@injectable()
export default class ScreenTypesStore {
    @observable os: ScreenType[] = [];
    @observable isLoading = false;

    @inject(types.mobileService)
    private readonly mobileService!: LaptopService;
    constructor() {
        makeObservable(this);
    }

    @action
    public init = async () => {
        this.isLoading = true;

        try {
            this.os = await this.mobileService.getScreenTypes();
        } catch (e) {
            if (e instanceof Error) {
                console.error(e.message);
            }
        }

        this.isLoading = false;
    }
}