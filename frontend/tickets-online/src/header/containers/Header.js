import React from 'react';
import { Link } from 'react-router-dom';
import { SearchFilmsForm } from '../../searchFilmsForm/components/SearchFilmsForm';
import { connect } from 'react-redux';
import { withRouter } from 'react-router-dom';
import { logout } from '../../user/actions/Actions';
import { setVisibilityFilter } from '../../searchBar/actions/ActionCreators';
import { fetchFilteredFilms } from '../../films/actions/Actions';
import { fetchUserTickets } from '../../ticket/actions/Actions';

class HeaderContainer extends React.Component {
  constructor(props) {
    super(props);
  }

  onInputChange = e => {
    this.props.setVisibilityFilter({
      film: e.target.value
    });
  };

  onSearchClick = () => {
    this.props.fetchFilteredFilms(this.props.visibilityFilters);
    if (this.props.history.location.pathname !== '/films') {
      this.props.history.push('/films');
    }
  };

  logout = () => {
    this.props.logout();
  };

  showUserTickets = () => {
    this.props.fetchUserTickets(this.props.user.userData.token);
    this.props.history.push('/tickets');
  };

  render() {
    return (
      <React.Fragment>
        <nav className="navbar navbar-inverse bg-dark justify-content-between">
          <Link to="/films" className="navbar-brand">
            Tickets Online
          </Link>
          <div className="col-xs-3">
            <SearchFilmsForm
              onInputChange={this.onInputChange}
              onSearchClick={this.onSearchClick}
            />
          </div>
          <div className="btn-group" role="group">
            {!this.props.user.userData.token ? (
              <button type="button" className="btn my-tickets-btn btn-link">
                <Link to="/login" className="nav-link">
                  Login
                </Link>
              </button>
            ) : (
              <React.Fragment>
                <div>
                  <p className="user-name-nav text-center">
                    Hello, {this.props.user.userData.firstName}
                  </p>
                </div>
                <div className="btn-group" role="group">
                  <button
                    onClick={this.showUserTickets}
                    type="button"
                    className="btn btn-link my-tickets-btn"
                  >
                    My Tickets
                  </button>
                  <button
                    onClick={this.logout}
                    type="button"
                    className="btn my-tickets-btn btn-link"
                  >
                    Log out
                  </button>
                </div>
              </React.Fragment>
            )}
            {!this.props.user.userData.token && (
              <button type="button" className="btn my-tickets-btn btn-link">
                <Link to="/register" className="nav-link">
                  Register
                </Link>
              </button>
            )}
          </div>
        </nav>
      </React.Fragment>
    );
  }
}

const mapStateToProps = state => ({
  user: state.user,
  visibilityFilters: state.searchBar.visibilityFilters
});

const mapDispatchToProps = dispatch => ({
  logout: () => dispatch(logout()),
  setVisibilityFilter: filters => dispatch(setVisibilityFilter(filters)),
  fetchFilteredFilms: filters => dispatch(fetchFilteredFilms(filters)),
  fetchUserTickets: token => dispatch(fetchUserTickets(token))
});

export default withRouter(connect(mapStateToProps, mapDispatchToProps)(HeaderContainer));
