import { useEffect } from 'react'
import { observer } from 'mobx-react-lite'
import ScreenTypesStore from '../../stores/ScreenTypesStore';
import { types, useInjection } from '../../../ioc';
import { Dropdown } from '../../../components/Dropdown';

type Props = {
    brandId?: number;
    onChange: (id?: number) => void;
}
export const ScreenTypeDropdown = observer((props: Props) => {
    const store = useInjection<ScreenTypesStore>(types.laptopScreenTypesStore);
    useEffect(() => { store.init() }, [store])

    return <Dropdown
        text='All Screen Type'
        items={store.screenTypes}
        onChange={props.onChange}
        selectedId={props.brandId}
    />
});