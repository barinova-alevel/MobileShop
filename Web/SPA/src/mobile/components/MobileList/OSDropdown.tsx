import { useEffect } from 'react'
import { observer } from 'mobx-react-lite'
import OSStore from '../../stores/OSStore';
import { types, useInjection } from '../../../ioc';
import { Dropdown } from '../../../components/Dropdown';

type Props = {
    osId?: number;
    onChange: (id?: number) => void;
}

export const OSDropdown = observer((props: Props) => {
    const store = useInjection<OSStore>(types.mobileOSStore);
    useEffect(() => { store.init() }, [store])

    return <Dropdown
        text='All OS'
        items={store.os}
        onChange={props.onChange}
        selectedId={props.osId}
    />
});