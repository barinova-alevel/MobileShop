import { inject, injectable } from "inversify";
import { action, makeObservable, observable, runInAction } from "mobx";
import { types } from "../../ioc";
import { Mobile, MobileFilter } from "../models/mobile";
import MobileService from "../services/MobileService";

@injectable()
export default class MobilesStore {
    @observable mobiles : Mobile[] = [];

    @observable isLoading = false;
    @observable totalPages = 0;
    @observable currentPage = 1;

    @inject(types.mobileService) 
    private readonly mobileService!: MobileService;
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

    private getByPage = async (page: number, filter?: MobileFilter) => {
        try {
            this.isLoading = true;
            const result = await this.mobileService.getByPage(page, filter);
            runInAction(()=> {
                this.mobiles = result.data;
                this.totalPages = result.pageCount;
            });
            
          } catch (e) {
            if (e instanceof Error) {
                console.error(e.message);
            }
          }
          runInAction(()=> {
            this.isLoading = false;
        });
    }
}
