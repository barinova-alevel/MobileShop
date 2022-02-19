import { inject, injectable } from "inversify";
import { action, makeObservable, observable } from "mobx";
import { types } from "../../ioc";
import { OperationSystem } from "../models/os";
import MobileService from "../services/MobileService";

@injectable()
export default class OSStore {
    @observable os: OperationSystem[] = [];
    @observable isLoading = false;

    @inject(types.mobileService)
    private readonly mobileService!: MobileService;
    constructor() {
        makeObservable(this);
    }

    @action
    public init = async () => {
        this.isLoading = true;

        try {
            this.os = await this.mobileService.getOS();
        } catch (e) {
            if (e instanceof Error) {
                console.error(e.message);
            }
        }

        this.isLoading = false;
    }
}