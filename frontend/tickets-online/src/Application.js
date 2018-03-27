import React from 'react'
import {Main} from './main/components/Main'
import HeaderContainer from './header/containers/Header'

import './bootstrap.css';
import './index.css'

const Application = () => (
  <div className="container-fluid navbar-container">
    <HeaderContainer />
    <Main />
  </div>
)

export default Application
