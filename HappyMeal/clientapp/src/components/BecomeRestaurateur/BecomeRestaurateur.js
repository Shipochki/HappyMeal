import { useContext, useEffect } from "react";
import { Navigate } from "react-router-dom";

import { AuthContext } from "../../contexts/AuthContext";

export const BecomeRestaurateur = () => {
  const { onBecomeRestaurateur, isAuthenticated } = useContext(AuthContext);

  useEffect(() => {
    if(isAuthenticated){
       onBecomeRestaurateur(); 
    }
  }, [onBecomeRestaurateur]);

  return <Navigate to="/" />;
};
