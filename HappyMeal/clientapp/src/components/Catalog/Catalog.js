import { useParams } from "react-router-dom"
import { CatalogItem } from "./CatalogItem/CatalogItem.js";

export const Catalog = () =>{
    const data = new Array(GetData());
    console.log(data);
    return (
        <section className="catalog">
          <h1>All Restaurants</h1>

          {data.map(x =>
            <CatalogItem key={x.id} {...x}/> 
          )}

          {data.length === 0 && (
            <h3 className="no-articles">No restaurants yet!</h3>
          )}
        </section>
    )
}

async function GetData(){
    const{ city } = useParams();

    const response = await fetch(`/api/restaurant/getallbycity`, {
      method: "POST", // GET, POST, PUT, DELETE, etc.
      mode: "cors", // no-cors,cors, same-origin
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(city),
    });

    const data = await response.json();

    return data;
}