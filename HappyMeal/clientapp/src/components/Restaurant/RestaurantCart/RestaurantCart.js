import { useContext } from "react";
import { Link } from "react-router-dom";
import { ResCartProduct } from "./ResCartProduct/ResCartProduct.js";
import { AuthContext } from "../../../contexts/AuthContext.js";

export const RestaurantCart = ({cart}) => {
    const { isAuthenticated } = useContext(AuthContext);

    if(!isAuthenticated){
        return(
            <div>
                <h2>Not login</h2>
                <Link to={"/login"}>Login</Link>
                </div>
            )
    }

    return(
        <div className="res-cart">
            <div className="res-cart-info">
                <h2>My Cart</h2>
                <p>Delivery costs: {cart.deliveryCosts} lv.</p>
                <p>Total: {cart.subtotal} lv.</p>
            </div>
            <div className="cart-products">
                {cart.products?.map(x =>
            <ResCartProduct key={x.id} {...x}/> 
          )}
            </div>
        </div>
    )
}