import React from 'react'
import {Main} from './main/components/Main'
import {Header} from './header/components/Header'
import {store} from './Store'
import {fetchFilms} from './films/actions/Actions'
import {logInUser, registerNewUser} from './user/actions/Actions'
import {FilmListContainer} from './films/containers/FilmListContainer'
import {connect} from 'react-redux'
import LoginForm from './loginForm/containers/LoginForm'
import {Switch, Route} from 'react-router-dom'
import {render} from 'react-dom'

import './bootstrap.css';

class Application extends React.Component {

  constructor(props) {
    super(props);
    this.state = {
      search: ''
    }
  }

  componentWillMount() {
    this.props.fetchFilms();
  }

  componentWillReceiveProps(newProps) {
    if (newProps.films) {
      this.setState({
        ...this.state,
        films: newProps.films
      })
    }
  }

  onInputChange = (e) => {
    this.setState({
      ...this.state,
      search: e.target.value
    })
  }

  onButtonClick = () => {
    this.setState({
      ...this.state,
      sessions: this.props.sessions.filter((session) => session.name.substr(this.state.search))
    })
  }

  render() {
    return (<Wrapper onInputChange={this.onInputChange}>
      <div className="container">
        <Switch>
          <Route exact path='/' component={FilmListContainer}/>
          <Route exact path='/login' component={LoginForm}/>
        </Switch>
      </div>
    </Wrapper>)
  }
}

const mapStateToProps = function(store) {
  return {
    films: store.film.films,
    isLoading: store.film.isFilmsLoading
  }
}

const mapDispatchToProps = (dispatch) =>({
  fetchFilms: () => dispatch(fetchFilms())
})

const App = connect(mapStateToProps, mapDispatchToProps)(Application);

const Wrapper = (props, store) => (<div className="container-fluid">
  <Header/> {props.children}
</div>)

export {
  App,
  store
}
