import React from 'react';
import Routes from './routes';
import HeaderContainer from './header/containers/Header';
import SearchBar from './searchBar/containers/SearchBar';

import './bootstrap.css';
import './index.css';

const Application = () => (
  <React.Fragment>
    <HeaderContainer />
    <SearchBar />
    <div className="container">
      <Routes />
    </div>
  </React.Fragment>
);

export default Application;
