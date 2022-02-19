import { useCallback, useEffect } from 'react'
import { observer } from 'mobx-react-lite'
import { useNavigate } from 'react-router-dom'
import { Col, Container, Row } from 'react-bootstrap'
import { BrandDropdown } from './BrandDropdown'
import { ScreenTypeDropdown } from './ScreenTypeDropdown'
import { types, useInjection } from '../../../ioc'
import LaptopsStore from '../../stores/LaptopsStore'
import DeviceList from '../../../components/DeviceList'

const LaptopList = observer(() => {
    const navigate = useNavigate();
    const store = useInjection<LaptopsStore>(types.laptopsStore);
    useEffect(() => { store.init() }, [store])
    const onCardClick = useCallback((id: number) => navigate(`/laptop/${id}`), []);
    const onBrandChange = useCallback(
        (id?: number) => store.changeFilter({ ...store.filter, laptopBrandId: id }),
        [])
    const onScreenTypeChange = useCallback(
        (id?: number) => store.changeFilter({ ...store.filter, screenTypeId: id }),
        [])
    return <>
        <Container className='mt-2 mb-4'>
            <Row>
                <Col sm={3}>
                    <BrandDropdown onChange={onBrandChange} />
                </Col>
                <Col sm={3}>
                    <ScreenTypeDropdown onChange={onScreenTypeChange} />
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

export default LaptopList
