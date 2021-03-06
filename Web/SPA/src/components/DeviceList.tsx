import { observer } from "mobx-react-lite";
import { useCallback } from "react";
import { Card, Col, Container, Row } from "react-bootstrap";
import { Device } from "../models/Device";
import { AddToBasketButton } from "../modules/basket/components";
import Pagination from "./Pagination";
import { Spinner } from "./Spinner";
import Price from "./Price";

type Props = {
    devices?: Device[];
    onCardClick: (id: number) => void;
    isLoading: boolean;
    totalPages: number;
    currentPage: number;
    onChangePage: (page: number) => void;
}

const DeviceList = observer((props: Props) => {
    return <Container>
        <Row>
            {props.isLoading ? (
                <Spinner />
            ) : (
                <>
                    {props.devices?.map((device, key) => (
                        <Col key={key} sm={6} md={6} lg={3} xl={3}>
                            {<DeviceCard
                                device={device}
                                onClick={props.onCardClick}
                            />}
                        </Col>
                    ))}
                    {
                        !props.devices?.length && <span>No corresponding device found. Try to change filter.</span>
                    }
                </>
            )}
        </Row>
        <Pagination
            total={props.totalPages}
            active={props.currentPage}
            onChange={props.onChangePage} />
    </Container>
})

type CardProps = {
    device: Device;
    onClick: (id: number) => void;
};

const DeviceCard = (props: CardProps) => {
    const { name, id, price, pictureUrl } = props.device
    const onClick = useCallback(() => props.onClick(id), [id]);

    if (!props.device) {
        return null
    }
    
    return (
        <Card
            className='box-shadow mx-2 mb-3'
            onClick={onClick}
            style={{ cursor: "pointer" }}>
            <Card.Img variant="top" src={pictureUrl} width={320} height={320} />
            <Card.Body>
                <Card.Title title={name} className='text-overflow'>{name}</Card.Title>
                <div className="d-flex justify-content-between align-items-center">
                    <div>
                        <Price value={price} />
                    </div>
                    <AddToBasketButton device={props.device} />
                </div>
            </Card.Body>
        </Card>
    )
}

export default DeviceList;