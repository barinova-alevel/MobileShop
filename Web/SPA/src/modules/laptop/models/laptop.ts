import { Brand } from "./brand";
import { ScreenType } from "./screenType";

export interface Laptop {
    id: number;
    name: string;
    description: string;
    price: number;
    pictureUrl: string;
    laptopBrand: Brand;
    screenType: ScreenType;
    availableStock: number;
    sku: string;
}

export type LaptopFilter = {
    laptopBrandId?: number;
    screenTypeId?: number;
}