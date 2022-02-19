import { Brand } from "./brand";
import { OperationSystem } from "./os";

export interface Mobile {
    id: number;
    name: string;
    description: string;
    price: number;
    pictureUrl: string;
    mobileBrand: Brand;
    operationSystem: OperationSystem;
    availableStock: number;
}

export type MobileFilter = {
    mobileBrandId?: number;
    OperationSystemId?: number;
}