import { inject, injectable } from "inversify";
import { action, makeAutoObservable, runInAction } from "mobx";
import { types } from "../../../ioc";
import { OperationSystem } from "../models/os";
import MobileService from "../services/MobileService";

@injectable()
export default class OSStore {
    os: OperationSystem[] = [];
    isLoading = false;

    @inject(types.mobileService)
    private readonly mobileService!: MobileService;
    constructor() {
        makeAutoObservable(this);
    }

    @action
    public init = async () => {
        this.isLoading = true;

        try {
            const os = await this.mobileService.getOS();
            runInAction(() => this.os = os)
        } catch (e) {
            if (e instanceof Error) {
                console.error(e.message);
            }
        }

        runInAction(() => this.isLoading = false);
    }
}