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
            }} className="card">
            <img src={`${imgUrlLink}`}/>
            <div>
                <h2>{name}</h2>
                <p>{deliveryTime}</p>
                <p>{minMoneyForOrder}</p>
                <p>{rating}</p>
            </div>
        </div>
    )
}
