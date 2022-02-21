import { inject, injectable } from "inversify";
import { makeAutoObservable, runInAction } from "mobx";
import { types } from "../../../ioc";
import { Laptop, LaptopFilter } from "../models/laptop";
import LaptopService from "../services/LaptopService";

const DEFAULT_PAGE = 1;

@injectable()
export default class LaptopsStore {
    mobiles: Laptop[] = [];
    isLoading = false;
    totalPages = 0;
    currentPage = DEFAULT_PAGE;
    filter?: LaptopFilter;

    @inject(types.laptopService)
    private readonly laptopService!: LaptopService;
    constructor() {
        makeAutoObservable(this);
    }

    public init = async () => {
        this.getByPage(this.currentPage);
    }

    public changePage = async (page: number) => {
        this.currentPage = page;
        this.getByPage(page, this.filter);
    }

    public changeFilter = async (filter: LaptopFilter) => {
        this.filter = filter;
        this.currentPage = DEFAULT_PAGE;
        this.getByPage(DEFAULT_PAGE, filter);
    }

    private getByPage = async (page: number, filter?: LaptopFilter) => {
        this.isLoading = true;

        try {
            const result = await this.laptopService.getByPage(page, filter);
            runInAction(() => {
                this.mobiles = result.data;
                this.totalPages = result.pageCount;
            })

        } catch (e) {
            if (e instanceof Error) {
                console.error(e.message);
            }
        }

        runInAction(() => this.isLoading = false);
    }
}
