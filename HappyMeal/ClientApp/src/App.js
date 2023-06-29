import { Routes, Route, useNavigate } from "react-router-dom";
import { Home } from "./components/Home/Home.js";
import { Header } from "./components/Header/Header.js";
import { Footer } from "./components/Footer/Footer.js";
import { Catalog } from "./components/Catalog/Catalog.js";
import { Menu } from "./components/Menu/Menu.js";
import { useState } from "react";
import { authServiceFactory } from "./services/authService.js";
import { AuthContext } from "./contexts/AuthContext.js";

function App() {
  const navigate = useNavigate();
  const [auth, setAuth] = useState({});
  const authService = authServiceFactory(auth.accessToken);

  const onLoginSubmit = async (data) => {
    try {
      const result = await authService.login(data);

      setAuth(result);

      navigate("/");
    } catch (error) {
      console.log("Login problem");
    }
  };

  const onRegisterSubmit = async (values) => {
    const { confirmPassword, ...registerData } = values;
    if (confirmPassword !== registerData.password) {
      return;
    }

    try {
      const result = await authService.register(registerData);

      setAuth(result);

      navigate("/");
    } catch (error) {
      console.log("Register problem");
    }
  };

  const onLogout = async () => {
    await authService.logout();

    setAuth({});
  };

  const contextValues = {
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
            <Route path="/menu" element={<Menu />} />
            <Route path="/catalog/:city" element={<Catalog />} />
          </Routes>
        </main>

        <Footer />
      </div>
    </AuthContext.Provider>
  );
}

export default App;
