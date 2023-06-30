import { Link } from "react-router-dom"
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome"
import { faMotorcycle } from "@fortawesome/free-solid-svg-icons"
import { faCartShopping } from "@fortawesome/free-solid-svg-icons"
import { faShoppingBag } from "@fortawesome/free-solid-svg-icons"

import './Menu.css'
import { useContext } from "react"
import { AuthContext } from "../../contexts/AuthContext"

export const Menu = () => {
    const { isAuthenticated } = useContext(AuthContext);

    return(
        <div className="menu">
            <div className="log-sign-btns">
                { isAuthenticated && (
                    <Link className="logout-btn" to={'/logout'}>Logout</Link>
                )}

                { !isAuthenticated && (
                    <div>
                        <Link className="login-btn" to={'/login'}>Login</Link>
                        <Link className="register-btn" to={'/register'}>Register</Link>
                    </div>
                )}
            </div>
            <Link className="cart" to={'/cart'}><FontAwesomeIcon icon={faShoppingBag}/> Cart</Link>
            <Link className="orders" to={'/orders'}><FontAwesomeIcon icon={faCartShopping}/>Orders</Link>
            <Link className="become" to={'/becomeRestaurateur'}><FontAwesomeIcon icon={faMotorcycle} />Become Restaurateur</Link>
        </div>
    )
}