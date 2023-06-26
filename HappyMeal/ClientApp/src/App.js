import { Routes, Route } from 'react-router-dom';
import { Home } from './components/Home/Home.js'

function App() {
  return (
    <div id='box'>
      <main id='main-content'>
        <Routes>
          <Route path='/' element={<Home />}></Route>
        </Routes>
      </main>
    </div>
  );
}

export default App;
