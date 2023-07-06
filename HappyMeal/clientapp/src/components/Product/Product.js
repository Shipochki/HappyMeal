import { FontAwesomeIcon } from "@fortawesome/react-fontawesome"
import { faPlus } from "@fortawesome/free-solid-svg-icons"
import { useContext } from "react";
import { AuthContext } from "../../contexts/AuthContext";

const data = {
    productId: 0,
    userId: 0
}

export const Product = ({
    id,
    name,
    description,
    price,
    weight
}) => {
    const { userId, addproudctToCart } = useContext(AuthContext);
    data["productId"] = id;
    data["userId"] = userId
    return(
        <div>
            <p>{name}</p>
            <p>{description}</p>
            <p>{price}</p>
            <p>{weight}</p>
            <button onClick={() => {
                addproudctToCart(data)
            }}><FontAwesomeIcon icon={faPlus} /></button>
        </div>
    )
}