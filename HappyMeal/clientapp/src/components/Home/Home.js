import { useState } from 'react';
import '../reset.css';
import './Home.css';
import { Link } from 'react-router-dom';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faLocationDot, faHamburger, faShoppingBag } from '@fortawesome/free-solid-svg-icons';


export const Home = () => {
    const [city, setCity] = useState("");

    return (
        <div>
            <div className='main-section'>
                <form>
                    <input onChange={(e) => setCity(e.target.value)} placeholder='City here...'></input>
                    <Link to={`/restaurants/:${city}`}>Search</Link>
                </form>
            </div>
            <div className='info'>
                <h3>How to order</h3>
                <h2>It's as easy as this.</h2>
                <div className='cards'>
                    <div className='card'>
                        <FontAwesomeIcon icon={faLocationDot}/>
                        <h4>Tell us where you are</h4>
                        <p>We'll show you restaurants in your city.</p>
                    </div>
                    <div className='card'>
                        <FontAwesomeIcon icon={faHamburger}/>
                        <h4>Find what you want</h4>
                        <p>Search for items, businesses.</p>
                    </div>
                    <div className='card'>
                        <FontAwesomeIcon icon={faShoppingBag}/>
                        <h4>Order for delivery</h4>
                        <p>We'll update you on your order's progress.</p>
                    </div>
                </div>
            </div>
        </div>
    )
}