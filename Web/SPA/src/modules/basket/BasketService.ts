import { inject, injectable } from "inversify";
import { types } from "../../ioc";
import { BasketAPI } from "../../services/BasketAPI";
import { IHttpService } from "../../services/HttpService";
import { Basket } from "./models/basket";
import { BasketItem } from "./models/basketItem";

type BasketResponse = {
    data: Basket
}

@injectable()
export default class BasketService {
    @inject(types.httpService)
    private readonly _httpService!: IHttpService;

    public set(items: BasketItem[]): Promise<Basket> {
        return this._httpService
            .postAsync<BasketResponse>(BasketAPI.set, { data: items })
            .then(_ => _.data);
    }

    public get(): Promise<Basket> {
        return this._httpService
            .postAsync<BasketResponse>(BasketAPI.get)
            .then(_ => _.data);
    }

    public async delete() {
        await this._httpService.postAsync(BasketAPI.delete);
    }
}