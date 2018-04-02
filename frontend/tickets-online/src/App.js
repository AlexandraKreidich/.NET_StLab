import React from 'react';
import Routes from './routes';
import HeaderContainer from './header/containers/Header';

import './bootstrap.css';
import './index.css'

const Application = () => (
  <div className="container-fluid navbar-container">
    <HeaderContainer />
    <div className="container">
      <Routes />
    </div>
  </div>
)

export default Application
