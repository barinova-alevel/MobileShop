import { inject, injectable } from "inversify";
import { makeAutoObservable, runInAction } from "mobx";
import { types } from "../../../ioc";
import { Mobile, MobileFilter } from "../models/mobile";
import MobileService from "../services/MobileService";

const DEFAULT_PAGE = 1;

@injectable()
export default class MobilesStore {
    mobiles: Mobile[] = [];
    isLoading = false;
    totalPages = 0;
    currentPage = DEFAULT_PAGE;
    filter?: MobileFilter;

    @inject(types.mobileService)
    private readonly mobileService!: MobileService;
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

    public changeFilter = async (filter: MobileFilter) => {
        this.filter = filter;
        this.currentPage = DEFAULT_PAGE;
        this.getByPage(DEFAULT_PAGE, filter);
    }

    private getByPage = async (page: number, filter?: MobileFilter) => {
        this.isLoading = true;

        try {
            const result = await this.mobileService.getByPage(page, filter);
            runInAction(() => {
                this.mobiles = result.data;
                this.totalPages = result.pageCount;
            });

        } catch (e) {
            if (e instanceof Error) {
                console.error(e.message);
            }
        }

        runInAction(() => this.isLoading = false);
    }
}
