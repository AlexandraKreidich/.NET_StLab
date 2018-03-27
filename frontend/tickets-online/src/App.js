import React from 'react'
import {Content} from './content/components/Content'
import HeaderContainer from './header/containers/Header'

import './bootstrap.css';
import './index.css'

const Application = () => (
  <div className="container-fluid navbar-container">
    <HeaderContainer />
    <Content />
  </div>
)

export default Application
