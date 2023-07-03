import { Link } from 'react-router-dom';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faBars } from '@fortawesome/free-solid-svg-icons';
import { faMotorcycle } from '@fortawesome/free-solid-svg-icons';
import { faBurger } from '@fortawesome/free-solid-svg-icons';

import '../reset.css';
import './Header.css';
import { useContext } from 'react';
import { AuthContext } from '../../contexts/AuthContext';

export const Header = () => {
    const { isCandidate, isRestaurateur } = useContext(AuthContext);

    return(
        <header>
        <h1><Link className='home' to={'/'}><FontAwesomeIcon icon={faBurger} />HappyMeal</Link></h1>
        <nav>
            {!isCandidate && !isRestaurateur &&(
                <Link to={'/becomeRestaurateur'}><FontAwesomeIcon icon={faMotorcycle} />Become Restaurateur</Link>                
            )}

            {isRestaurateur && (
                <Link to={'/createRestaurant'}>Add Restaurant</Link>
            )}

            <Link to={'/menu'}><FontAwesomeIcon icon={faBars} /></Link>
        </nav>
        </header>
    )
}