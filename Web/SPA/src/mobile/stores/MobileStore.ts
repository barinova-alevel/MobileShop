import { inject, injectable } from "inversify";
import { action, makeObservable, observable, runInAction } from "mobx";
import { types } from "../../ioc";
import { Mobile } from "../models/mobile";
import MobileService from "../services/MobileService";

@injectable()
export default class MobileStore {
    @observable mobile: Mobile | null = null;
    @observable isLoading = false;

    @inject(types.mobileService)
    private readonly mobileService!: MobileService
    constructor() {
        makeObservable(this);
    }

    @action
    public init = async (id: number) => {
        this.isLoading = true;
        
        try {
            const result = await this.mobileService.getById(id);
            this.mobile = result;

        } catch (e) {
            if (e instanceof Error) {
                console.error(e.message);
            }
        }

        this.isLoading = false;
    }
}
