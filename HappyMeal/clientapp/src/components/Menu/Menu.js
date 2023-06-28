import { Link } from "react-router-dom"
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome"
import { faMotorcycle } from "@fortawesome/free-solid-svg-icons"
import { faCartShopping } from "@fortawesome/free-solid-svg-icons"
import { faShoppingBag } from "@fortawesome/free-solid-svg-icons"

import './Menu.css'

export const Menu = () => {
    return(
        <div className="menu">
            <div className="log-sign-btns">
                <Link className="login-btn" to={'/login'}>Login</Link>
                <Link className="register-btn" to={'/register'}>Register</Link>
            </div>
            <Link className="cart" to={'/cart'}><FontAwesomeIcon icon={faShoppingBag}/> Cart</Link>
            <Link className="orders" to={'/orders'}><FontAwesomeIcon icon={faCartShopping}/>Orders</Link>
            <Link className="become" to='/becomeRestaurateur'><FontAwesomeIcon icon={faMotorcycle} />Become Restaurateur</Link>
        </div>
    )
}