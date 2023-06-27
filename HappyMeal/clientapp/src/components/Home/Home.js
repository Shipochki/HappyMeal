import '../reset.css';
import './Home.css';
import { Link } from 'react-router-dom';

export const Home = () => {
    return(
        <div className='main-section'>
            <form>
                <input placeholder='City here...'></input>
                <Link>Search</Link>
            </form>
        </div>
    )
}