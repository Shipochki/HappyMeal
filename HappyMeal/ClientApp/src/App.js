import { Routes, Route, useNavigate, useParams } from "react-router-dom";
import { Home } from "./components/Home/Home.js";
import { Header } from "./components/Header/Header.js";
import { Footer } from "./components/Footer/Footer.js";
import { Catalog } from "./components/Catalog/Catalog.js";
import { Menu } from "./components/Menu/Menu.js";
import { useEffect, useState } from "react";
import { authServiceFactory } from "./services/authService.js";
import { AuthContext } from "./contexts/AuthContext.js";
import { restaurantServiceFactory } from "./services/restaurantService.js";
import { Login } from "./components/Login/Login.js";
import { Register } from "./components/Register/Register.js";

function App() {
  const navigate = useNavigate();
  const [restaurants, setRestaurants] = useState([]);
  const [auth, setAuth] = useState({});
  const restaurantService = restaurantServiceFactory(auth.accessToken);
  const authService = authServiceFactory(auth.accessToken);

  //useEffect(() => {
  //  restaurantService.getAll()
  //  .then((result) => {
  //    setRestaurants(result);
  //  });
  //});

  const getCatalogSubmit = async (city) => {
    try{
      const response = await fetch(`/api/restaurant/getallbycity`, {
      method: "POST", // GET, POST, PUT, DELETE, etc.
      mode: "cors", // no-cors,cors, same-origin
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(city['city']),
    });

    const data = await response.json();

    setRestaurants(data);

    navigate('/catalog')
    } catch (error){
      console.log("Get problem");
    }
  }

  const onLoginSubmit = async (loginFormKeys) => {
    try {
      const response = await fetch(`/api/user/login`, {
        method: "POST", // GET, POST, PUT, DELETE, etc.
        mode: "cors", // no-cors,cors, same-origin
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(loginFormKeys),
      });
  
      const result = await response.json();

      setAuth(result);

      navigate("/");
    } catch (error) {
      console.log("Login problem");
    }
  };

  const onRegisterSubmit = async (registerFormKeys) => {
    const { confirmPassword, ...registerData } = registerFormKeys;
    if (confirmPassword !== registerData.password) {
      return;
    }

    try {
      const response = await fetch(`/api/user/register`, {
        method: "POST", // GET, POST, PUT, DELETE, etc.
        mode: "cors", // no-cors,cors, same-origin
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(registerFormKeys),
      });
  
      const result = await response.json();

      setAuth(result);

      navigate("/");
    } catch (error) {
      console.log("Login problem");
    }
  };

  const onLogout = async () => {
    await authService.logout();

    setAuth({});
  };

  const contextValues = {
    getCatalogSubmit,
    onLoginSubmit,
    onRegisterSubmit,
    onLogout,
    userId: auth._id,
    token: auth.accessToken,
    userEmail: auth.email,
    isAuthenticated: !!auth.accessToken,
  };

  return (
    <AuthContext.Provider value={contextValues}>
      <div id="box">
        <Header />

        <main id="main-content">
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path='/login' element={<Login />} />
            <Route path='/register' element={<Register/>} />
            <Route path="/menu" element={<Menu />} />
            <Route path="/catalog" element={<Catalog restaurants={restaurants}/>} />
          </Routes>
        </main>

        <Footer />
      </div>
    </AuthContext.Provider>
  );
}

export default App;
