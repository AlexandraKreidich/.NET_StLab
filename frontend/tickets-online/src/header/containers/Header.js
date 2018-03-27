import React from 'react'
import {Link} from 'react-router-dom'
import {SearchFilmsForm} from '../../searchFilmsForm/components/SearchFilmsForm'
import {Header} from '../components/Header'
import {connect} from 'react-redux'
import {withRouter} from 'react-router-dom'
import {logoutUser} from '../../user/actions/ActionCreators'
import {setVisibilityFilter} from '../../films/actions/ActionCreators'

class HeaderContainer extends React.Component {

  constructor(props) {
    super(props);
  }

  onInputChange = (e) => {
    this.props.setVisibilityFilter({
      filmName: e.target.value
    });
  }

  onSearchClick = () => {}

  logout = () => {
    this.props.logoutUser();
  }

  render() {
    return (<nav className="navbar navbar-light bg-light justify-content-between">
      <div className="col-xs-3">
        <Link to='/' className="navbar-brand">
          <img className="logo-img" src="logo.svg" width="30" height="30" alt=""/>
          TicketsOnline
        </Link>
      </div>
      <div className="col-xs-3">
        <SearchFilmsForm onInputChange={this.onInputChange} onSearchClick={this.onSearchClick}/>
      </div>
      <div className="col-xs-3">
        {
          this.props.user.token
            ? <span className="navbar-text">
                {this.props.user.email}
              </span>
            : <span className="navbar-text"></span>
        }
      </div>
      <div className="col-xs-3">
        <div className="btn-group" role="group">
          {
            !this.props.user.token
              ? <button type="button" className="btn btn-link">
                  <Link to='/login'>Login</Link>
                </button>
              : <button onClick={this.logout} type="button" className="btn btn-link">
                  Log out
                </button>
          }

          <button type="button" className="btn btn-link">
            <Link to='/register'>Register</Link>
          </button>
        </div>
      </div>
    </nav>)
  }
}

const mapStateToProps = (state) => ({
  user: state.user.userData,
  visibilityFilters: state.film.visibilityFilters
})

const mapDispatchToProps = (dispatch) => ({
  logoutUser: () => dispatch(logoutUser()),
  setVisibilityFilter: (filters) => dispatch(setVisibilityFilter(filters))
})

export default withRouter(connect(mapStateToProps, mapDispatchToProps)(HeaderContainer));
