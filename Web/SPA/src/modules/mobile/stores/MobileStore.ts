import { inject, injectable } from "inversify";
import { action, makeAutoObservable, runInAction } from "mobx";
import { types } from "../../../ioc";
import { Mobile } from "../models/mobile";
import MobileService from "../services/MobileService";

@injectable()
export default class MobileStore {
    mobile: Mobile | null = null;
    isLoading = false;

    @inject(types.mobileService)
    private readonly mobileService!: MobileService
    constructor() {
        makeAutoObservable(this);
    }

    public init = async (id: number) => {
        this.isLoading = true;
        
        try {
            const result = await this.mobileService.getById(id);
            runInAction(() => this.mobile = result);
        } catch (e) {
            if (e instanceof Error) {
                console.error(e.message);
            }
        }

        runInAction(() =>this.isLoading = false);
    }
}
