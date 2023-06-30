import { useContext } from 'react';
import '../reset.css';
import './Home.css';
import { Link } from 'react-router-dom';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faLocationDot, faHamburger, faShoppingBag, faX } from '@fortawesome/free-solid-svg-icons';
import { useForm } from '../../hooks/useForm';
import { AuthContext } from '../../contexts/AuthContext';

const city = {
    city: 'city'
}

export const Home = () => {
    const { getCatalogSubmit } = useContext(AuthContext);
    const { values, changeHandler, onSubmit } = useForm({
        [city.city]: '',
    }, getCatalogSubmit);
    return (
        <div>
            <div className='main-section'>
                <form method='POST' onSubmit={onSubmit}>
                    <div className='input'>
                        <input placeholder='City here...' name={city.city} value={values[city.city]} onChange={changeHandler}></input>
                        <button type='reset' onClick={changeHandler} onClickCapture={() => {values[city.city] = ''}}><FontAwesomeIcon icon={faX}/></button>
                    </div>
                    <input className='input-submit' type='submit' value={'Search'}/>
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