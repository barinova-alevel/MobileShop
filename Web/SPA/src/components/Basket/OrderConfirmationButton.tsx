import { observer } from "mobx-react-lite";
import { useCallback } from "react";
import { Button } from "react-bootstrap";
import { useNavigate } from "react-router-dom";
import { types, useInjection } from "../../ioc";
import { AuthStore } from "../../stores/AuthStore";
import BasketStore from "../../basket/BasketStore";

interface OrderConfirmationProps {
    onConfirm: () => void;
}

const OrderConfirmationButton = observer((props: OrderConfirmationProps) => {
    const basketStore = useInjection<BasketStore>(types.basketStore);
    const loginStore = useInjection<AuthStore>(types.authStore)
    const navigate = useNavigate();
    const onClick = useCallback(() => {
        if (!loginStore.isUserLoggedIn) {
            navigate(`/login`)
            return;
        }
        basketStore.makeOrder()
        props.onConfirm()
    }, [])

    return <Button className="flex-fill" variant="success" onClick={onClick}>Confirm</Button>
})
export default OrderConfirmationButton;