import { inject, injectable } from "inversify";
import { action, makeObservable, observable, runInAction } from "mobx";
import ownTypes from "../ioc/ownTypes";
import { Product } from "../models/Product";
import CatalogService from "../services/CatalogService";

@injectable()
export default class CatalogStore {
    @observable products : Product[] = [];
    @observable isLoading = false;
    @observable totalPages = 0;
    @observable currentPage = 1;

    @inject(ownTypes.catalogService) 
    private readonly catalogService!: CatalogService;
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

    private getByPage = async (page: number) => {
        try {
            this.isLoading = true;
            const result = await this.catalogService.getByPage(page);
            runInAction(()=> {
                this.products = result.data;
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
