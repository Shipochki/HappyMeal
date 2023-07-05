export const Restaurant = ({
    restaurant
}) =>{
    return(
        <div className="main">
            <h2>{restaurant.name}</h2>
            <p>{restaurant.deliveryTime}</p>
            <p>{restaurant.minMoneyForOrder}</p>
            <p>{restaurant.description}</p>
            <img src={`${restaurant.imgLinkUrl}`}/>
        </div>
    )
}