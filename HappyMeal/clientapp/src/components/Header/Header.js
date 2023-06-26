import { Link } from 'react-router-dom';

import './Header.css';

export const Header = () => {
    return(
        <header>
        <h1><Link className='home' to='/'>HappyMeal</Link></h1>
        <nav>
            <Link to='/bacomeRestaurateur'>Become Restaurateur</Link>
        </nav>
        </header>
    )
}