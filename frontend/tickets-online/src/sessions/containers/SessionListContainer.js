import React from 'react';
import { connect } from 'react-redux';
import { store } from '../../App';
import { SessionsList } from '../components/SessionList';
import { fetchSessionsForFilm } from '../actions/Actions';
import loadImg from '../../load-img.gif';

import '../../bootstrap.css';
import '../../index.css';

class SessionsContainer extends React.Component {
  constructor(props) {
    super(props);
  }

  componentDidMount() {
    this.props.fetchSessionsForFilm(this.props.match.params.filmId);
  }

  render() {
    return (
      <div className="top-indent">
        {this.props.isLoading && (
          <div className="text-center div-load-img">
            <img className="img-responsive" width="50px" height="50px" src={loadImg} />
          </div>
        )}
        {this.props.sessions && <SessionsList sessions={this.props.sessions} />}
      </div>
    );
  }
}

const mapStateToProps = function(store) {
  return { isLoading: store.session.isSessionsLoading, sessions: store.session.sessions };
};

const mapDispatchToProps = dispatch => ({
  fetchSessionsForFilm: filmId => dispatch(fetchSessionsForFilm(filmId))
});

const SessionsListContainer = connect(mapStateToProps, mapDispatchToProps)(SessionsContainer);

export { SessionsListContainer };
