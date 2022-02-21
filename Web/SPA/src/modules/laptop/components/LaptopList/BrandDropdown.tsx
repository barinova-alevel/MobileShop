import { useEffect } from 'react'
import { observer } from 'mobx-react-lite'
import BrandsStore from '../../stores/BrandStore';
import { types, useInjection } from '../../../../ioc';
import { Dropdown } from '../../../../components/Dropdown';

type Props = {
    onChange: (id?: number) => void;
}
export const BrandDropdown = observer((props: Props) => {
    const store = useInjection<BrandsStore>(types.laptopBrandsStore);
    useEffect(() => { store.init() }, [store])

    return <Dropdown
        text='All Brands'
        items={store.brands}
        onChange={props.onChange}
    />
});