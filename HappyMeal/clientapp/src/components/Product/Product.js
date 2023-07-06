import { FontAwesomeIcon } from "@fortawesome/react-fontawesome"
import { faPlus } from "@fortawesome/free-solid-svg-icons"

export const Product = ({
    id,
    name,
    description,
    type,
    price,
    weight
}) => {
    const { addproudctToCart } = useContext(AuthContext);
    return(
        <div>
            <p>{name}</p>
            <p>{description}</p>
            <p>{price}</p>
            <p>{weight}</p>
            <button onClick={() => {
                addproudctToCart({
                    id,
                    name,
                    description,
                    type,
                    price,
                    weight
                })
            }}><FontAwesomeIcon icon={faPlus} /></button>
        </div>
    )
}