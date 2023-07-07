import { useContext } from "react";
import { Link } from "react-router-dom";
import { AuthContext } from "../../contexts/AuthContext";
import { Product } from "../Product/Product";
import "./Restaurant.css";

export const Restaurant = ({
    restaurant
}) =>{
    const { restaurateurId, isRestaurateur } = useContext(AuthContext);
    return(
        <div className="main">
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
    )
}