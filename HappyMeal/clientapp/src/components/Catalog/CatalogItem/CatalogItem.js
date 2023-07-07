import { useContext } from "react";
import { AuthContext } from "../../../contexts/AuthContext";
import "./CatalogItem.css";

export const CatalogItem = ({
    id,
    name,
    deliveryTime,
    imgUrlLink,
    minMoneyForOrder,
    rating
}) => {
    const { getRestaurantById } = useContext(AuthContext);
    return(
        <div onClick={() => {
                getRestaurantById(id);
            }} className="cat-card">
            <div className="card-img" style={{backgroundImage: `url(${imgUrlLink})`}}></div>
            <div className="card-info">
                <h2>{name}</h2>
                <p>Delivery Time: {deliveryTime} min.</p>
                <p>Min money for Order: {minMoneyForOrder}lv.</p>
                <p>Rating: {rating}</p>
            </div>
        </div>
    )
}
