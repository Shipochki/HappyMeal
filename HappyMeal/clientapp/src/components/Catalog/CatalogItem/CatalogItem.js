import { Link } from "react-router-dom"

export const CatalogItem = ({
    id,
    name,
    deliveyTime,
    imgUrlLink,
    minMoneyForOrder,
    rating
}) => {
    return(
        <div className="card">
            <h2>{name}</h2>
            <p>{deliveyTime}</p>
            <p>{minMoneyForOrder}</p>
            <p>{rating}</p>
            <img src={`${imgUrlLink}`}/>
            <Link to={`/restaurant`}>Details</Link>
        </div>
    )
}