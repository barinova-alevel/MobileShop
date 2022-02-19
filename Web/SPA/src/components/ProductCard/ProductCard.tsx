import { Card } from 'react-bootstrap'
import { Product } from '../../models/Product'
import { useNavigate } from 'react-router-dom';
import AddToBasketButton from '../AddToBasketButton';
import { Price } from '../Utils';

interface Props {
  product: Product | null
}

const ProductCard = (props: Props) => {
  const navigate = useNavigate();
  if (!props.product) {
    return null
  }
  const { name, id, price, pictureUrl: avatar } = props.product

  return (
    <Card
      className='box-shadow mx-2 mb-3'
      onClick={() => { navigate(`/product/${id}`); }}
      style={{ cursor: "pointer" }}>
      <Card.Img variant="top" src={avatar} width={320} height={320}/>
      <Card.Body>
        <Card.Title title={name} className='text-overflow'>{name}</Card.Title>
        <div className="d-flex justify-content-between align-items-center">
          <div>
            <Price value={price} />
          </div>
          <AddToBasketButton product={props.product} />
        </div>
      </Card.Body>
    </Card>
  )
}

export default ProductCard;
