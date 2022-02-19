import { useEffect } from 'react'
import { Col, Container, Row } from 'react-bootstrap'
import { observer } from 'mobx-react-lite'
import { useInjection } from '../../ioc/ioc.react'
import ownTypes from '../../ioc/ownTypes'
import ProductStore from '../../stores/ProductStore'
import { useParams } from 'react-router-dom'
import AddToBasketButton from '../AddToBasketButton'
import { Price } from '../Utils'

const ProductDetails = observer(() => {
    const store = useInjection<ProductStore>(ownTypes.productStore);
    let params = useParams<{ id: string }>();
    useEffect(() => {
        store.init(+params.id!);
    }, [store, params.id])

    if (!store.product) {
        return null;
    }

    const { name, price, pictureUrl: avatar, description } = store.product
    return (
        <Container>
            <Row>
                <Col md={{ offset: 1, span: 10 }}>
                    <div className="d-flex">
                        <div className="flex-shrink-0">
                            <img
                                className="media-object"
                                src={avatar}
                                style={{ width: 400, height: 400 }} />
                        </div>
                        <div className="flex-grow-1 ms-3">
                            <h3>{name}</h3>
                            <div>
                                {description}
                            </div>
                            <div className='d-flex mt-4'>
                                <Price className="me-auto" value={price} />
                                <AddToBasketButton product={store.product} />
                            </div>
                        </div>
                    </div>
                </Col>
            </Row>
        </Container>
    )
});

export default ProductDetails