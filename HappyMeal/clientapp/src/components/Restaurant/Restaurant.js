import { useContext } from "react";
import { Link } from "react-router-dom";
import { AuthContext } from "../../contexts/AuthContext";
import { Product } from "../Product/Product";

export const Restaurant = ({
    restaurant
}) =>{
    const { restaurateurId, isRestaurateur } = useContext(AuthContext);
    return(
        <div className="main">
            <h2>{restaurant.name}</h2>
            <p>{restaurant.deliveryTime}</p>
            <p>{restaurant.minMoneyForOrder}</p>
            <p>{restaurant.description}</p>
            <img src={`${restaurant.imgLinkUrl}`}/>
            {isRestaurateur && restaurateurId === restaurant.ownerId && (
                <Link to={`/addProduct`}>Add Product</Link>
            )}
            <div>
                {restaurant.products.map(x =>
            <Product key={x.id} {...x}/> 
            )}
            </div>
        </div>
    )
}