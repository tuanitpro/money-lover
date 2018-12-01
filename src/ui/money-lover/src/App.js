import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';

import Home from './pages/Home';
import FulllCalendar from './pages/FullCalendar';
class App extends Component {
  render() {
    return (
      <div className="App">
      <Home />
      <FulllCalendar />
      </div>
    );
  }
}

export default App;
