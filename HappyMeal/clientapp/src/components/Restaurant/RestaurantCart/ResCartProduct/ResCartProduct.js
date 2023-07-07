import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faX } from "@fortawesome/free-solid-svg-icons";
import { useContext } from "react"
import { AuthContext } from "../../../../contexts/AuthContext";

const data = {
    productId: 0,
    userId: 0
}

export const ResCartProduct = ({
    id,
    name,
    price,
    weight
}) => {
    const { userId, removeProductFromCart } = useContext(AuthContext);
    data["productId"] = id;
    data["userId"] = userId
    return(
        <div className="card-product">
            <p>{name}</p>
            <p>Price: {price}</p>
            <p>Weight: {weight}</p>
            <button onClick={() => {
                removeProductFromCart(data);
            }}><FontAwesomeIcon icon={faX}/></button>
        </div>
    )
}