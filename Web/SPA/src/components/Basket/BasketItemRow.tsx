import { observer } from "mobx-react-lite";
import { Button } from "react-bootstrap";
import NumericInput from "react-numeric-input";
import { Link } from "react-router-dom";
import { types, useInjection } from "../../ioc";
import BasketStore, { BasketItem } from "../../stores/BasketStore";
import { Price } from "../Utils";

const BasketItemRow = observer((props: BasketItem) => {
    const store = useInjection<BasketStore>(types.basketStore);
    const { pictureUrl: avatar, name, id, price } = props.product;
    return <tr>
        <td className="col-sm-8 col-md-6">
            <div className="d-flex">
                <div className="flex-shrink-0">
                    <img
                        className="media-object"
                        src={avatar}
                        style={{ width: 72, height: 72 }} />
                </div>
                <div className="flex-grow-1 ms-3">
                    <Link to={`/product/${id}`}>{name}</Link>
                </div>
            </div>
        </td>
        <td className="col-sm-1 col-md-1" style={{ textAlign: 'center' }}>
            <NumericInput
                min={1}
                max={10}
                value={props.count}
                onChange={(changedNumber) => {
                    if (changedNumber !== null)
                        store.updateCount(id, changedNumber)
                }} />
        </td>
        <td className="col-sm-1 col-md-1 text-center">
            <strong><Price value={price} /></strong>
        </td>
        <td className="col-sm-1 col-md-1 text-center">
            <strong><Price value={price * props.count} /></strong>
        </td>
        <td className="col-sm-1 col-md-2 text-end">
            <Button
                variant="danger"
                onClick={(e: React.MouseEvent<HTMLButtonElement>) => {
                    e.stopPropagation()
                    store.removeFromBasket(props.product);
                }}> Remove </Button>
        </td>
    </tr>;
})
export default BasketItemRow;