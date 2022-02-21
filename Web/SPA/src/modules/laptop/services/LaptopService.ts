import { inject, injectable } from "inversify";
import { Brand } from "../models/brand";
import { Paginated } from "../../../models/Paginated";
import CatalogAPI, { toDto } from "../../../services/CatalogAPI";
import { PaginatedDto } from "../../../dtos/PaginatedDto";
import { ScreenType } from "../models/screenType";
import { Laptop, LaptopFilter } from "../models/laptop";
import { types } from "../../../ioc";
import { IHttpService } from "../../../services/HttpService";

@injectable()
export default class LaptopService {
    @inject(types.httpService)
    private readonly _httpService!: IHttpService;

    public getByPage(page: number, filter?: LaptopFilter): Promise<PaginatedDto<Laptop>> {
        return this._httpService.postAsync<Paginated<Laptop>>(CatalogAPI.Laptop.getLaptops, {
            pageIndex: page - 1,
            pageSize: CatalogAPI.PageSize,
            filter: filter
        }).then(toDto)
    }

    public getById(id: number) {
        return this._httpService.postAsync<Laptop>(CatalogAPI.Laptop.getById, { id });
    }

    public getBrands(): Promise<Brand[]> {
        return this._httpService.postAsync<Brand[]>(CatalogAPI.Laptop.getBrands, {});
    }

    public getScreenTypes(): Promise<ScreenType[]> {
        return this._httpService.postAsync<ScreenType[]>(CatalogAPI.Laptop.getScreenTypes, {});
    }
}