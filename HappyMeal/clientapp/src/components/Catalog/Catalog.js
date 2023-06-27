import { useParams } from "react-router-dom"

export const Catalog = () =>{
    const data = GetData()

    return (
        <div>Hello</div>
    )
}

async function GetData(){
    const{ city } = useParams();

    const response = await fetch(`/api/restaurant/getallbycity/${city}`)

    const data = await response.json();
}