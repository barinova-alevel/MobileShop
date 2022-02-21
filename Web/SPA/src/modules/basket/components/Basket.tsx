import { observer } from "mobx-react-lite";
import { useState } from "react";
import Icon from "../../../components/Icon";
import BasketList from "./BasketList";

const Basket = observer(() => {
    const [isConfirmed, setConfirmed] = useState(false)
    return isConfirmed
        ? <div className='centered'>
            <Icon name="check2-square" size={150} />
            <h1 className="h3 mb-3 font-weight-normal">Order confirmed</h1>
        </div>
        : <BasketList onConfirm={() => setConfirmed(true)} />;
})
export default Basket;