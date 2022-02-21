import { useEffect } from 'react'
import { observer } from 'mobx-react-lite'
import { useParams } from 'react-router-dom'
import DeviceDetails from '../../../components/DeviceDetails'
import { types, useInjection } from '../../../ioc'
import MobileStore from '../stores/MobileStore'

export const MobileDetails = observer(() => {
    const store = useInjection<MobileStore>(types.mobileStore);
    let params = useParams<{ id: string }>();
    useEffect(() => {
        store.init(+params.id!);
    }, [store, params.id])

    if (!store.mobile) {
        return null;
    }

    return <DeviceDetails
        device={store.mobile}
    />
});