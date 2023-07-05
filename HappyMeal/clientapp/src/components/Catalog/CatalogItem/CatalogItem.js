import { useContext } from "react";
import { AuthContext } from "../../../contexts/AuthContext";

export const CatalogItem = ({
    id,
    name,
    deliveyTime,
    imgUrlLink,
    minMoneyForOrder,
    rating
}) => {
    const { getRestaurantById } = useContext(AuthContext);
    return(
        <div className="card">
            <h2>{name}</h2>
            <p>{deliveyTime}</p>
            <p>{minMoneyForOrder}</p>
            <p>{rating}</p>
            <img src={`${imgUrlLink}`}/>
            <form method="POST">
            <a onClick={() => {
                getRestaurantById(id);
            }}>Details</a>
            </form>
        </div>
    )
}
