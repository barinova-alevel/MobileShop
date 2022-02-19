import { observer } from "mobx-react-lite"
import { useCallback } from "react"
import { types, useInjection } from "../ioc"
import { Device } from "../models/Device"
import BasketStore from "../stores/BasketStore"

interface ButtonProps {
    device: Device
}

const AddToBasketButton = observer((props: ButtonProps) => {
    const { device } = props
    const store = useInjection<BasketStore>(types.basketStore)
    const onClick = useCallback((e: React.MouseEvent<HTMLButtonElement>) => {
        e.stopPropagation()
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