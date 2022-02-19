import "reflect-metadata";
import { injectable } from "inversify";
import { Product } from "../../models/Product";
import { Brand } from "../models/brand";
import { OperationSystem } from "../models/os";
import { post } from "../../fetch-utils";
import { Paginated } from "../../models/Paginated";
import { Mobile, MobileFilter } from "../models/mobile";
import CatalogAPI, { toDto } from "../../services/CatalogAPI";
import { PaginatedDto } from "../../dtos/PaginatedDto";

@injectable()
export default class MobileService {
    public getByPage(page: number, filter?: MobileFilter): Promise<PaginatedDto<Mobile>> {
        return post<Paginated<Mobile>>(CatalogAPI.Mobile.getMobiles, {
            pageIndex: page - 1,
            pageSize: CatalogAPI.PageSize,
            filter: filter
        }).then(toDto)
    }

    public getById(id: number) {
        return post<Mobile>(CatalogAPI.Mobile.getById, { id });
    }

    public getBrands(): Promise<Brand[]> {
        return post<Brand[]>(CatalogAPI.Mobile.getBrands, {});
    }

    public getOS(): Promise<OperationSystem[]> {
        return post<Brand[]>(CatalogAPI.Mobile.getOS, {});
    }
}