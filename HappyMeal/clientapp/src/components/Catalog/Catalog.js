import { CatalogItem } from "./CatalogItem/CatalogItem.js";

export const Catalog = ({
  restaurants
}) =>{
    return (
        <section className="catalog">
          <h1>Order from {restaurants.length} places</h1>

          {restaurants.map(x =>
            <CatalogItem key={x.id} {...x}/> 
          )}

          {restaurants.length === 0 && (
            <h3 className="no-articles">No restaurants yet!</h3>
          )}
        </section>
    )
}