import { observer } from "mobx-react-lite";
import { Badge } from "react-bootstrap";
import Icon from "../../../components/Icon";
import { types, useInjection } from "../../../ioc";
import BasketStore from "../BasketStore";

const BasketIcon = observer(() => {
    const store = useInjection<BasketStore>(types.basketStore)
    return <div>
      <Icon name="basket" size={20} />
      {
        !!store.basket.totalQuantity && <Badge
          className="small-badge"
          bg="dark" pill>
          {store.basket.totalQuantity}
        </Badge>
      }
    </div>
  });

  export default BasketIcon;