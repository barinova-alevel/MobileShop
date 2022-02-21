import { useEffect } from 'react'
import { observer } from 'mobx-react-lite'
import BrandsStore from '../../stores/BrandStore';
import { types, useInjection } from '../../../../ioc';
import { Dropdown } from '../../../../components/Dropdown';

type Props = {
    brandId?: number;
    onChange: (id?: number) => void;
}
export const BrandDropdown = observer((props: Props) => {
    const store = useInjection<BrandsStore>(types.mobileBrandsStore);
    useEffect(() => { store.init() }, [store])

    return <Dropdown
        text='All Brands'
        items={store.brands}
        onChange={props.onChange}
        selectedId={props.brandId}
    />
});