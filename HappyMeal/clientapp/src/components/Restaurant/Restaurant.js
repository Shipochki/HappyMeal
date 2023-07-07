import { useContext } from "react";
import { Link } from "react-router-dom";
import { AuthContext } from "../../contexts/AuthContext";
import { Product } from "../Product/Product";
import "./Restaurant.css";
import { RestaurantCart } from "./RestaurantCart/RestaurantCart";

export const Restaurant = ({
    restaurant,
    cart
}) =>{
    const { restaurateurId, isRestaurateur, isAuthenticated, withGetCartByUserId } = useContext(AuthContext);
    if(isAuthenticated){
       cart = withGetCartByUserId();
    }
    return(
        <div className="main-res">
            <div className="main-left">
                <img src={`${restaurant.imgLinkUrl}`}/>
            <div className="res-info"> 
                <h2>{restaurant.name}</h2>
                <p>Delivery Time: {restaurant.deliveryTime} min.</p>
                <p>Min money for order: {restaurant.minMoneyForOrder} lv.</p>
                <p>Description: {restaurant.description}</p>
            </div>
            <div className="products">
                <h3>Products:</h3>
                {isRestaurateur && restaurateurId === restaurant.ownerId && (
                <Link to={`/addProduct`}>Add Product</Link>
            )}
                {restaurant.products.map(x =>
            <Product key={x.id} {...x}/> 
            )}
            </div>
            </div>
            <div className="main-right">
                <RestaurantCart cart={cart} />
            </div>
        </div>
    )
}