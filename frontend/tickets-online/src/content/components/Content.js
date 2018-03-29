import React from 'react'
import {Switch, Route} from 'react-router-dom'
import {FilmListContainer} from '../../films/containers/FilmListContainer'
import LoginForm from '../../loginForm/containers/LoginForm'
import RegisterForm from '../../registerForm/containers/RegisterForm'


import '../../bootstrap.css';

const Content = () => (<div className="container">
  <Switch>
    <Route exact path='/' component={FilmListContainer}/>
    <Route exact path='/login' component={LoginForm}/>
    <Route exact path='/register' component={RegisterForm}/>
  </Switch>
</div>)

export {
  Content
}
