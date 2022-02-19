import { inject, injectable } from "inversify";
import { action, makeObservable, observable, runInAction } from "mobx";
import { types } from "../../ioc";
import { Laptop, LaptopFilter } from "../models/laptop";
import LaptopService from "../services/LaptopService";

const DEFAULT_PAGE = 1;

@injectable()
export default class LaptopsStore {
    @observable mobiles: Laptop[] = [];

    @observable isLoading = false;
    @observable totalPages = 0;
    @observable currentPage = DEFAULT_PAGE;
    @observable filter?: LaptopFilter;

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
        this.getByPage(page, this.filter);
    }

    @action
    public changeFilter = async (filter: LaptopFilter) => {
        this.filter = filter;
        this.currentPage = DEFAULT_PAGE;
        this.getByPage(DEFAULT_PAGE, filter);
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
