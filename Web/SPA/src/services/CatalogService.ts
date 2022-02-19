import "reflect-metadata";
import { injectable } from "inversify";
import { Product } from "../models/Product";

type ProductsDto = { pageCount: number, data: Product[] };

export interface CatalogService {
    getById(id: number): Promise<Product>;
    getByPage(page: number): Promise<ProductsDto>;
}

const PAGE_SIZE = 12;

async function post<T>(url: string, data: any): Promise<T> {
    const response = await fetch(url, {
        method: 'POST',
        mode: 'cors',
        headers: {
            'Content-Type': 'application/json'
        },
        redirect: 'follow',
        referrerPolicy: 'no-referrer',
        body: JSON.stringify(data)
    });
    return response.json();
}

@injectable()
export default class DefaultUserService implements CatalogService {

    public async getById(id: number): Promise<Product> {
        // const product = this._products.find(_ => _.id == id);
        // if (!product) {
        //     throw new Error("Not found");
        // }

        return {
            id: 1,
            name: "Oppo A53s",
            price: 7990,
            pictureUrl: "https://content2.rozetka.com.ua/goods/images/big/31161253.jpg",
            description: `Экран (6.43", LCD, 1600x720) / Qualcomm Snapdragon 460 (1.8 ГГц + 1.6 ГГц) / тройная основная камера: 13 Мп + 2 Мп + 2 Мп, фронтальная 8 Мп / RAM 4 ГБ / 64 ГБ встроенной памяти + microSD (до 256 ГБ) / 3G / LTE / GPS / поддержка 2х SIM-карт (Nano-SIM) / Android 10 / 5000 мА*ч`
        };
    }


    public async getByIds(ids: number[]): Promise<Product[]> {
        return [{
            id: 1,
            name: "Oppo A53s",
            price: 7990,
            pictureUrl: "https://content2.rozetka.com.ua/goods/images/big/31161253.jpg",
            description: `Экран (6.43", LCD, 1600x720) / Qualcomm Snapdragon 460 (1.8 ГГц + 1.6 ГГц) / тройная основная камера: 13 Мп + 2 Мп + 2 Мп, фронтальная 8 Мп / RAM 4 ГБ / 64 ГБ встроенной памяти + microSD (до 256 ГБ) / 3G / LTE / GPS / поддержка 2х SIM-карт (Nano-SIM) / Android 10 / 5000 мА*ч`
        }]; // this._products.filter(_ => ~ids.indexOf(_.id))
    }

    public getByPage(page: number): Promise<ProductsDto> {
        return post<{ data: Product[], count: number }>("http://www.alevelwebsite.com/api/catalog/v1/mobilebff/mobiles", {
            pageIndex: (page - 1) * PAGE_SIZE,
            pageSize: PAGE_SIZE
        }).then(_ => ({
            data: _.data,
            pageCount: Math.ceil(_.count / PAGE_SIZE)
        }))
    }
}
