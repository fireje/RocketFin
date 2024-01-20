import React from 'react';
import { Outlet } from "react-router";
import logo from './logo.svg';
import './App.css';
import Navbar from "./Components/Navbar/Navbar";

function App() {
    return (
        <>
            <div className="App">
                <header className="App-header">
                   
                    <Navbar />
                </header>

                <Outlet />
            </div>

            
           
        </>
    );
}

export default App;
