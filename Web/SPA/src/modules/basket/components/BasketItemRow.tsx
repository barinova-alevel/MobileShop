import { observer } from "mobx-react-lite";
import { Button } from "react-bootstrap";
import NumericInput from "react-numeric-input";
import { types, useInjection } from "../../../ioc";
import BasketStore from "../../basket/BasketStore";
import { BasketItem } from "../../basket/models/basketItem";
import Price from "../../../components/Price";

const BasketItemRow = observer((props: BasketItem) => {
    const store = useInjection<BasketStore>(types.basketStore);
    const { pictureUrl, deviceName, sku, price, quantity } = props;
    return <tr>
        <td className="col-sm-8 col-md-6">
            <div className="d-flex">
                <div className="flex-shrink-0">
                    <img
                        className="media-object"
                        src={pictureUrl}
                        style={{ width: 72, height: 72 }} />
                </div>
                <div className="flex-grow-1 ms-3">
                    {deviceName}
                </div>
            </div>
        </td>
        <td className="col-sm-1 col-md-1" style={{ textAlign: 'center' }}>
            <NumericInput
                min={1}
                max={10}
                value={quantity}
                onChange={(changedNumber) => {
                    if (changedNumber !== null)
                        store.updateCount(sku, changedNumber)
                }} />
        </td>
        <td className="col-sm-1 col-md-1 text-center">
            <strong><Price value={price} /></strong>
        </td>
        <td className="col-sm-1 col-md-1 text-center">
            <strong><Price value={price * quantity} /></strong>
        </td>
        <td className="col-sm-1 col-md-2 text-end">
            <Button
                variant="danger"
                onClick={(e: React.MouseEvent<HTMLButtonElement>) => {
                    e.stopPropagation()
                    store.removeFromBasket(sku);
                }}> Remove </Button>
        </td>
    </tr>;
})
export default BasketItemRow;