import { useCallback, useEffect } from 'react'
import { observer } from 'mobx-react-lite'
import { types, useInjection } from '../ioc'
import MobilesStore from './stores/MobilesStore'
import DeviceList from '../components/DeviceList'
import { useNavigate } from 'react-router-dom'

const MobileList = observer(() => {
    const navigate = useNavigate();
    const store = useInjection<MobilesStore>(types.mobilesStore);
    useEffect(() => { store.init() }, [store])
    const onCardClick = useCallback((id: number) => navigate(`/mobile/${id}`), []);
    return <DeviceList
        currentPage={store.currentPage}
        isLoading={store.isLoading}
        onCardClick={onCardClick}
        onChangePage={store.changePage}
        totalPages={store.totalPages}
        devices={store.mobiles}
    />
});

export default MobileList
