import { observer } from "mobx-react-lite";
import { Col, Container, Row, Table } from "react-bootstrap";
import { types, useInjection } from "../../ioc";
import BasketStore from "../../basket/BasketStore";
import { Icon, Price } from "../Utils";
import BasketItemRow from "./BasketItemRow";
import OrderConfirmationButton from "./OrderConfirmationButton";

type BasketListProps = {
    onConfirm: () => void;
}

const BasketList = observer((props: BasketListProps) => {
    const store = useInjection<BasketStore>(types.basketStore);
    if (!store.basket.items) {
        return <div className='centered'>
            <Icon name="basket" size={150} />
            <h1 className="h3 mb-3 font-weight-normal mt-3">Empty basket</h1>
        </div>
    }

    return <Container>
        <Row>
            <Col sm={12} lg={{ offset: 1, span: 10 }}>
                <Table hover={true}>
                    <thead>
                        <tr>
                            <th>Product</th>
                            <th>Quantity</th>
                            <th className="text-center">Price</th>
                            <th className="text-center">Total</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        {store.basket.items.map((item, key) => <BasketItemRow {...item} />)}
                        <tr>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td><h3>Total</h3></td>
                            <td className="text-end">
                                <h3><strong><Price value={store.basket.totalPrice} /></strong></h3>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td className="d-flex">
                                <OrderConfirmationButton onConfirm={props.onConfirm} />
                            </td>
                        </tr>
                    </tbody>
                </Table>
            </Col>
        </Row>
    </Container>
});
export default BasketList;