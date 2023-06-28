import { Link } from 'react-router-dom';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faBars } from '@fortawesome/free-solid-svg-icons';
import { faMotorcycle } from '@fortawesome/free-solid-svg-icons';
import { faBurger } from '@fortawesome/free-solid-svg-icons';

import '../reset.css';
import './Header.css';

export const Header = () => {
    return(
        <header>
        <h1><Link className='home' to='/'><FontAwesomeIcon icon={faBurger} />HappyMeal</Link></h1>
        <nav>
            <Link to='/becomeRestaurateur'><FontAwesomeIcon icon={faMotorcycle} />Become Restaurateur</Link>
            <Link to='/menu'><FontAwesomeIcon icon={faBars} /></Link>
        </nav>
        </header>
    )
}