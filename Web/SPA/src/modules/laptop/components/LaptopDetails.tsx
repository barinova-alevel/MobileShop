import { useEffect } from 'react'
import { observer } from 'mobx-react-lite'
import { useParams } from 'react-router-dom'
import DeviceDetails from '../../../components/DeviceDetails'
import { types, useInjection } from '../../../ioc'
import LaptopStore from '../stores/LaptopStore'

export const LaptopDetails = observer(() => {
    const store = useInjection<LaptopStore>(types.laptopStore);
    let params = useParams<{ id: string }>();
    useEffect(() => {
        store.init(+params.id!);
    }, [store, params.id])

    if (!store.laptop) {
        return null;
    }

    return <DeviceDetails
        device={store.laptop}
    />
});