import { PaginatedDto } from "../dtos/PaginatedDto";
import { Paginated } from "../models/Paginated";

const baseUrl = 'http://www.alevelwebsite.com/api/catalog/v1';

const mobileBaseUrl = `${baseUrl}/mobilebff`;
const MobileAPI = {
    getMobiles: `${mobileBaseUrl}/mobiles`,
    getById: `${mobileBaseUrl}/mobile`,
    getBrands: `${mobileBaseUrl}/brands`,
    getOS: `${mobileBaseUrl}/OperationSystems`
}

const laptopBaseUrl = `${baseUrl}/laptopbff`;
const LaptopAPI = {
    getLaptops: `${laptopBaseUrl}/laptops`,
    getById: `${laptopBaseUrl}/laptop`,
    getBrands: `${laptopBaseUrl}/brands`,
    getScreenTypes: `${laptopBaseUrl}/screenTypes`
}

const CatalogAPI = {
    Mobile: MobileAPI,
    Laptop: LaptopAPI,
    PageSize: 6
}

export default CatalogAPI;

export function toDto<T>(paginated: Paginated<T>): PaginatedDto<T> {
    return {
        data: paginated.data,
        pageCount: Math.ceil(paginated.count / CatalogAPI.PageSize)
    }
}