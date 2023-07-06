import { CartProduct } from "./CartProduct/CartProduct"
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome"
import { faX } from "@fortawesome/free-solid-svg-icons"
import { useContext } from "react"
import { AuthContext } from "../../contexts/AuthContext"

export const Cart = ({cart}) => {
    const { removeProductFromCart } = useContext(AuthContext);
    return(
        <div>
        <h2>My Cart</h2>
        <p>{cart.deliveryCosts}</p>
        <p>{cart.subtotal}</p>
        {cart.products.map(x =>
            <CartProduct key={x.id} {...x}/> 
          )}
          <button onClick={() => {

          }}><FontAwesomeIcon icon={faX}/></button>
        </div>
    )
}