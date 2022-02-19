import { observer } from "mobx-react-lite"
import { useCallback } from "react"
import { types, useInjection } from "../ioc"
import { Product } from "../models/Product"
import BasketStore from "../stores/BasketStore"

interface ButtonProps {
    product: Product
}

const AddToBasketButton = observer((props: ButtonProps) => {
    const { product } = props
    const store = useInjection<BasketStore>(types.basketStore)
    const onClick = useCallback((e: React.MouseEvent<HTMLButtonElement>) => {
        e.stopPropagation()
        store.addToBasket(product)
    }, [store])

    return (
        <button
            className='btn btn-sm btn-outline-secondary'
            onClick={onClick}>
            {store.isInBasket(product) ? "In Basket" : "Buy"}
        </button>
    )
})
export default AddToBasketButton