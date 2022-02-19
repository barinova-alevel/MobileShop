import { inject, injectable } from "inversify";
import { action, makeObservable, observable, runInAction } from "mobx";
import { types } from "../../ioc";
import { Laptop, LaptopFilter } from "../models/laptop";
import LaptopService from "../services/LaptopService";

@injectable()
export default class LaptopsStore {
    @observable mobiles: Laptop[] = [];

    @observable isLoading = false;
    @observable totalPages = 0;
    @observable currentPage = 1;

    @inject(types.laptopService)
    private readonly laptopService!: LaptopService;
    constructor() {
        makeObservable(this);
    }

    @action
    public init = async () => {
        this.getByPage(this.currentPage);
    }

    @action
    public changePage = async (page: number) => {
        this.currentPage = page;
        this.getByPage(page);
    }

    @action
    private getByPage = async (page: number, filter?: LaptopFilter) => {
        this.isLoading = true;

        try {
            const result = await this.laptopService.getByPage(page, filter);
            this.mobiles = result.data;
            this.totalPages = result.pageCount;

        } catch (e) {
            if (e instanceof Error) {
                console.error(e.message);
            }
        }
        
        this.isLoading = false;
    }
}
