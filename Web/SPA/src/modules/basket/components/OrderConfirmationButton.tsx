import { observer } from "mobx-react-lite";
import { useCallback } from "react";
import { Button } from "react-bootstrap";
import { types, useInjection } from "../../../ioc";
import BasketStore from "../../basket/BasketStore";

interface OrderConfirmationProps {
    onConfirm: () => void;
}

const OrderConfirmationButton = observer((props: OrderConfirmationProps) => {
    const basketStore = useInjection<BasketStore>(types.basketStore);
    const onClick = useCallback(() => {
        basketStore.makeOrder()
        props.onConfirm()
    }, [])

    return <Button className="flex-fill" variant="success" onClick={onClick}>Confirm</Button>
})
export default OrderConfirmationButton;