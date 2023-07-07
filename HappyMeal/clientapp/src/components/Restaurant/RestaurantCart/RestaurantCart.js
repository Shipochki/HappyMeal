import { useContext } from "react";
import { CartProduct } from "../../Cart/CartProduct/CartProduct"
import { AuthContext } from "../../../contexts/AuthContext";

export const RestaurantCart = ({cart}) => {
    const { isAuthenticated } = useContext(AuthContext);

    if(!isAuthenticated){
        return(
                <h2>Empty</h2>
            )
    }

    return(
        <div className="res-cart">
        <h2>My Cart</h2>
        <p>{cart.deliveryCosts}</p>
        <p>{cart.subtotal}</p>
        {cart.products.map(x =>
            <CartProduct key={x.id} {...x}/> 
          )}
        </div>
    )
}