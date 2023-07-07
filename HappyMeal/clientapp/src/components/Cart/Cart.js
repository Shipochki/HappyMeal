import { CartProduct } from "./CartProduct/CartProduct"

export const Cart = ({cart}) => {
    return(
        <div>
        <h2>My Cart</h2>
        <p>{cart.deliveryCosts}</p>
        <p>{cart.subtotal}</p>
        {cart.products.map(x =>
            <CartProduct key={x.id} {...x}/> 
          )}
        </div>
    )
}