import { observer } from "mobx-react-lite"
import { useCallback } from "react"
import { types, useInjection } from "../../../ioc"
import { Device } from "../../../models/Device"
import { AuthService } from "../../auth/AuthService"
import { AuthStore } from "../../auth/AuthStore"
import BasketStore from "../BasketStore"

interface ButtonProps {
    device: Device
}

const AddToBasketButton = observer((props: ButtonProps) => {
    const { device } = props
    const store = useInjection<BasketStore>(types.basketStore)
    const authService = useInjection<AuthService>(types.authService)
    const onClick = useCallback((e: React.MouseEvent<HTMLButtonElement>) => {
        e.stopPropagation()
        
        if (!authService.isAuthenticated()) {
            authService.signinRedirect();
            return;
        }

        store.addToBasket(device)
    }, [store])

    return (
        <button
            className='btn btn-sm btn-outline-secondary'
            onClick={onClick}>
            {store.isInBasket(device) ? "In Basket" : "Buy"}
        </button>
    )
})
export default AddToBasketButton