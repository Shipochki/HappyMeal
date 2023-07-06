import { Product } from "../Product/Product"

export const Cart = ({cart}) => {
    return(
        <div>
        <h2>My Cart</h2>
        <p>{cart.deliveryCosts}</p>
        <p>{cart.subtotal}</p>
        {cart.products.map(x =>
            <Product key={x.id} {...x}/> 
          )}
        </div>
    )
}