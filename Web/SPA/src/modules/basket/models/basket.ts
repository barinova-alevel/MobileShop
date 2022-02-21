import { BasketItem } from "./basketItem";

export interface Basket {
    totalPrice: number;
    totalQuantity: number;
    items: BasketItem[];
}