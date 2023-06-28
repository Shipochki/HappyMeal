import { useParams } from "react-router-dom"

export const Catalog = () =>{
    const data = GetData()

    return (
        <div>Hello</div>
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
}