import { useState } from 'react';
import spoon from './assets/winking-spoon.png';
import cigPack from './assets/cig-pack.png';
import './App.css';

async function GenerateMessage() {
  console.log('Fetching mum message from API');
  try {
    const response = await fetch('https://localhost:32769/placeholder');
    const data = await response.json();
    return data.message; 
  } catch (error) {
    console.error('Error fetching data:', error);
    return "Error fetching message"; 
  }
}

function App() {
  const [phrase, setMessage] = useState(""); // State to store the message

  const handleClick = async () => {
    const message = await GenerateMessage();
    setMessage(message); 
  };

  return (
    <div className="App">
      <div>
        <a target="_blank">
          <img src={cigPack} className="logo" alt="Vite logo" />
        </a>
        <a target="_blank">
          <img src={spoon} className="logo" alt="Cig logo" />
        </a>
      </div>
      
      <h2>{phrase}</h2>
      <div className="card">
        <button onClick={handleClick}>
          Reveal Mum's Message...
        </button>
      </div>
      <p className="read-the-docs">
        Mum phrase generator
      </p>
    </div>
  );
}

export default App;
