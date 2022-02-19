import "reflect-metadata";
import { injectable } from "inversify";
import { Brand } from "../models/brand";
import { post } from "../../fetch-utils";
import { Paginated } from "../../models/Paginated";
import CatalogAPI, { toDto } from "../../services/CatalogAPI";
import { PaginatedDto } from "../../dtos/PaginatedDto";
import { ScreenType } from "../models/screenType";
import { Laptop, LaptopFilter } from "../models/laptop";

@injectable()
export default class LaptopService {
    public getByPage(page: number, filter?: LaptopFilter): Promise<PaginatedDto<Laptop>> {
        return post<Paginated<Laptop>>(CatalogAPI.Laptop.getLaptops, {
            pageIndex: page - 1,
            pageSize: CatalogAPI.PageSize,
            filter: filter
        }).then(toDto)
    }

    public getById(id: number) {
        return post<Laptop>(CatalogAPI.Laptop.getById, { id });
    }

    public getBrands(): Promise<Brand[]> {
        return post<Brand[]>(CatalogAPI.Mobile.getBrands, {});
    }

    public getScreenTypes(): Promise<ScreenType[]> {
        return post<ScreenType[]>(CatalogAPI.Laptop.getScreenTypes, {});
    }
}