import { useCallback, useEffect } from 'react'
import { observer } from 'mobx-react-lite'
import { types, useInjection } from '../ioc'
import DeviceList from '../components/DeviceList'
import { useNavigate } from 'react-router-dom'
import LaptopsStore from './stores/LaptopsStore'

const LaptopList = observer(() => {
    const navigate = useNavigate();
    const store = useInjection<LaptopsStore>(types.laptopsStore);
    useEffect(() => { store.init() }, [store])
    const onCardClick = useCallback((id: number) => navigate(`/laptop/${id}`), []);
    return <DeviceList
        currentPage={store.currentPage}
        isLoading={store.isLoading}
        onCardClick={onCardClick}
        onChangePage={store.changePage}
        totalPages={store.totalPages}
        devices={store.mobiles}
    />
});

export default LaptopList
