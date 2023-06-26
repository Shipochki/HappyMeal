export const Home = () => {
    return(
        <button onClick={GetAllCities}></button>
    )
}

async function GetAllCities(){
    const response = await fetch('/api/city/all', {
        method: "GET", // GET, POST, PUT, DELETE, etc.
      mode: "cors", // no-cors,cors, same-origin
      cache: "no-cache", // default, no-cache, reload, force-cache, only-if-cached
      credentials: "same-origin", // include,same-origin, omit
      headers: {
        "Content-Type": "application/json",
      }
      });

    const data = await response.json();

    console.log(data)
}