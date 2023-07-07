import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faX } from "@fortawesome/free-solid-svg-icons";
import { useContext } from "react";
import { AuthContext } from "../../../contexts/AuthContext";

const data = {
    productId: 0,
    userId: 0
}

export const CartProduct = ({
    id,
    name,
    description,
    price,
    weight
}) => {
    const { userId, removeProductFromCart } = useContext(AuthContext);
    data["productId"] = id;
    data["userId"] = userId
    return(
        <div>
            <p>{name}</p>
            <p>{description}</p>
            <p>{price}</p>
            <p>{weight}</p>
            <button onClick={() => {
                removeProductFromCart(data);
            }}><FontAwesomeIcon icon={faX}/></button>
        </div>
    )
}