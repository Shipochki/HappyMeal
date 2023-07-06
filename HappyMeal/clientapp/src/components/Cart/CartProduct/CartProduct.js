export const CartProduct = ({
    name,
    description,
    price,
    weight
}) => {
    return(
        <div>
            <p>{name}</p>
            <p>{description}</p>
            <p>{price}</p>
            <p>{weight}</p>
        </div>
    )
}