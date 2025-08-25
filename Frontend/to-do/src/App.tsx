import Home from './pages/Home/Home';
import { ToastContainer } from 'react-toastify';

import "./assets/css/Index.scss";
import "./assets/css/Colours.scss";

function App() {
  return (<>
    <ToastContainer position="bottom-right" autoClose={3000} hideProgressBar={true} closeButton={false} />
    <Home />
  </>
  )
}

export default App
