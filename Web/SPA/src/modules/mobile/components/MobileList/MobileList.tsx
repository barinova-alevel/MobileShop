import { useCallback, useEffect } from 'react'
import { observer } from 'mobx-react-lite'
import { useNavigate } from 'react-router-dom'
import { Col, Container, Row } from 'react-bootstrap'
import { BrandDropdown } from './BrandDropdown'
import { OSDropdown } from './OSDropdown'
import { types, useInjection } from '../../../../ioc'
import MobilesStore from '../../stores/MobilesStore'
import DeviceList from '../../../../components/DeviceList'

const MobileList = observer(() => {
    const navigate = useNavigate();
    const store = useInjection<MobilesStore>(types.mobilesStore);
    useEffect(() => { store.init() }, [store])
    const onCardClick = useCallback((id: number) => navigate(`/mobile/${id}`), []);
    const onBrandChange = useCallback(
        (id?: number) => store.changeFilter({ ...store.filter, mobileBrandId: id }),
        [])
    const onOSChange = useCallback(
        (id?: number) => store.changeFilter({ ...store.filter, operationSystemId: id }),
        [])
    return <>
        <Container className='mt-2 mb-4'>
            <Row>
                <Col sm={3}>
                    <BrandDropdown onChange={onBrandChange} />
                </Col>
                <Col sm={3}>
                    <OSDropdown onChange={onOSChange} />
                </Col>
            </Row>
        </Container>
        <DeviceList
            currentPage={store.currentPage}
            isLoading={store.isLoading}
            onCardClick={onCardClick}
            onChangePage={store.changePage}
            totalPages={store.totalPages}
            devices={store.mobiles}
        />
    </>
});

export default MobileList
