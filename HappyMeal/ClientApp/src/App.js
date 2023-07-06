import { Routes, Route, useNavigate } from "react-router-dom";
import { Home } from "./components/Home/Home.js";
import { Header } from "./components/Header/Header.js";
import { Footer } from "./components/Footer/Footer.js";
import { Catalog } from "./components/Catalog/Catalog.js";
import { Menu } from "./components/Menu/Menu.js";
import { useState } from "react";
import { authServiceFactory } from "./services/authService.js";
import { AuthContext } from "./contexts/AuthContext.js";
import { Login } from "./components/Login/Login.js";
import { Register } from "./components/Register/Register.js";
import { Logout } from "./components/Logout/Logout.js"
import { BecomeRestaurateur } from "./components/BecomeRestaurateur/BecomeRestaurateur.js";
import { Candidates } from "./components/Candidates/Candidates.js";
import { AddRestaurant } from "./components/AddRestaurant/AddRestaurant.js";
import { Restaurant } from "./components/Restaurant/Restaurant.js";
import { AddProduct } from "./components/AddProduct/AddProduct.js";
import { Cart } from "./components/Cart/Cart.js";

function App() {
  const navigate = useNavigate();
  const [restaurants, setRestaurants] = useState([]);
  const [candidates, setCandidates] = useState([]);
  const [auth, setAuth] = useState({});
  const [restaurant, setRestaurant] = useState({});
  const [cart, setCart] = useState({});
  const authService = authServiceFactory(auth.accessToken);

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

  const onBecomeRestaurateur = async () => {
    try {
      const response = await fetch(`/api/restaurateur/become`, {
        method: "POST", // GET, POST, PUT, DELETE, etc.
        mode: "cors", // no-cors,cors, same-origin
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(auth),
      });
  
      const result = await response.json();

      navigate("/");
    } catch (error) {
      console.log("BecomeRestaurateur problem");
    }
  }

  const getAllCandidates = async () => {
    try{
      const response = await fetch(`/api/restaurateur/getallcandidates`, {
      method: "GET", // GET, POST, PUT, DELETE, etc.
    });

    const data = await response.json();

    setCandidates(data);

    navigate('/menu')
    } catch (error){
      console.log("candidates problem");
    }
  }

  const getCartByUserId = async () => {
    const userId = auth.id;
    try {
      const response = await fetch(`/api/cart/getcartbyuserid`, {
        method: "POST", // GET, POST, PUT, DELETE, etc.
        mode: "cors", // no-cors,cors, same-origin
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(userId),
      });
  
      const result = await response.json();

      setCart(result);

      navigate('/cart')
    } catch (error) {
      console.log("getCart problem");
    }
  }

  const addproudctToCart = (product) => {

  }

  const getRestaurantById = async (idr) => {
    const id = idr;
    try {
      const response = await fetch(`/api/restaurant/detailsrestaurant`, {
        method: "POST", // GET, POST, PUT, DELETE, etc.
        mode: "cors", // no-cors,cors, same-origin
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(id),
      });
  
      const result = await response.json();

      setRestaurant(result);

      navigate('/restaurant')
    } catch (error) {
      console.log("getRestaurant problem");
    }
  }

  const onCreateProduct = async (createFormKeys) => {
    try {
      const response = await fetch(`/api/product/addProduct`, {
        method: "POST", // GET, POST, PUT, DELETE, etc.
        mode: "cors", // no-cors,cors, same-origin
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(createFormKeys),
      });
  
      const id = await response.json();

      navigate(`/restaurant`);
    } catch (error) {
      console.log("create product problem");
    }
  }

  const approveCandidate = async (id) => {
    try {
      const response = await fetch(`/api/restaurateur/approvecandidate`, {
        method: "POST", // GET, POST, PUT, DELETE, etc.
        mode: "cors", // no-cors,cors, same-origin
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(id.id),
      });
  
      const result = await response.json();

      navigate("/menu");
    } catch (error) {
      console.log("approveCandidate problem");
    }
  }

  const onCreateRestaurant = async (createFormKeys) => {
    try {
      const response = await fetch(`/api/restaurant/createrestaurant`, {
        method: "POST", // GET, POST, PUT, DELETE, etc.
        mode: "cors", // no-cors,cors, same-origin
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(createFormKeys),
      });
  
      const id = await response.json();

      navigate(`/restaurant/${id}`);
    } catch (error) {
      console.log("create problem");
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

      localStorage.setItem("auth", result);

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
      console.log("Register problem");
    }
  };

  const onLogout = async () => {
    setAuth({});
  };

  const contextValues = {
    getCatalogSubmit,
    getAllCandidates,
    onBecomeRestaurateur,  
    approveCandidate,  
    onLoginSubmit,
    onRegisterSubmit,
    onLogout,
    onCreateRestaurant,
    getRestaurantById,
    onCreateProduct,
    getCartByUserId,
    userId: auth.id,
    restaurateurId: auth.restaurateurId,
    token: auth.accessToken,
    userEmail: auth.email,
    isCandidate: auth.isCandidate,
    isRestaurateur: auth.isRestaurateur,
    isAdmin: auth.isAdmin,
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
            <Route path='/logout' element={<Logout />} />
            <Route path="/menu" element={<Menu />} />
            <Route path="/catalog" element={<Catalog restaurants={restaurants}/>} />
            <Route path="/becomeRestaurateur" element={<BecomeRestaurateur/>} />
            <Route path="/candidates" element={<Candidates candidates={candidates}/>} />
            <Route path="/createRestaurant" element={<AddRestaurant />} />
            <Route path="/restaurant" element={<Restaurant restaurant={restaurant}/>} />
            <Route path="/addProduct" element={<AddProduct restaurant={restaurant}/>} />
            <Route path="/cart" element={<Cart cart={cart}/>} />
          </Routes>
        </main>

        <Footer />
      </div>
    </AuthContext.Provider>
  );
}

export default App;
