import "reflect-metadata";
import { inject, injectable } from "inversify";
import { Brand } from "../models/brand";
import { OperationSystem } from "../models/os";
import { Paginated } from "../../models/Paginated";
import { Mobile, MobileFilter } from "../models/mobile";
import CatalogAPI, { toDto } from "../../services/CatalogAPI";
import { PaginatedDto } from "../../dtos/PaginatedDto";
import { types } from "../../ioc";
import { IHttpService } from "../../services/HttpService";

@injectable()
export default class MobileService {
    @inject(types.httpService)
    private readonly _httpService!: IHttpService;

    public getByPage(page: number, filter?: MobileFilter): Promise<PaginatedDto<Mobile>> {
        return this._httpService.postAsync<Paginated<Mobile>>(CatalogAPI.Mobile.getMobiles, {
            pageIndex: page - 1,
            pageSize: CatalogAPI.PageSize,
            filter: filter
        }).then(toDto)
    }

    public getById(id: number) {
        return this._httpService.postAsync<Mobile>(CatalogAPI.Mobile.getById, { id });
    }

    public getBrands(): Promise<Brand[]> {
        return this._httpService.postAsync<Brand[]>(CatalogAPI.Mobile.getBrands, {});
    }

    public getOS(): Promise<OperationSystem[]> {
        return this._httpService.postAsync<OperationSystem[]>(CatalogAPI.Mobile.getOS, {});
    }
}