import { Routes, Route } from 'react-router-dom';
import { Home } from './components/Home/Home.js';
import { Header } from './components/Header/Header.js';
import { Footer } from './components/Footer/Footer.js';
import { Catalog } from './components/Catalog/Catalog.js';
import { Menu } from './components/Menu/Menu.js';

function App() {
  return (
    <div id='box'>
      <Header />

      <main id='main-content'>
        <Routes>
          <Route path='/' element={<Home />}/>
          <Route path='/menu' element={<Menu />}/>
          <Route path='/catalog/city' element={<Catalog/>}/>
        </Routes>
      </main>

      <Footer/>
    </div>
  );
}

export default App;
