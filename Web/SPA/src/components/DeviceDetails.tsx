import { Col, Container, Row } from 'react-bootstrap'
import { observer } from 'mobx-react-lite'
import AddToBasketButton from './AddToBasketButton'
import { Price } from './Utils'
import { Device } from '../models/Device'

type Props = {
    device?: Device;
}

const DeviceDetails = observer((props: Props) => {
    if (!props.device) {
        return null;
    }

    const { name, price, pictureUrl: avatar, description } = props.device
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
                                <AddToBasketButton device={props.device} />
                            </div>
                        </div>
                    </div>
                </Col>
            </Row>
        </Container>
    )
});

export default DeviceDetails