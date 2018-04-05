import React from 'react';
import PropTypes from 'prop-types';
import moment from 'moment';

import '../../bootstrap.css';
import '../../index.css';

class Session extends React.Component {
  constructor(props) {
    super(props);
  }

  onClick = e => {
    e.preventDefault();
    this.props.onSessionClick(this.props.hallId, this.props.id, this.props.cinemaName);
  };

  render() {
    return (
      <a
        href="#"
        className="film-item list-group-item list-group-item-action flex-column align-items-start"
        onClick={this.onClick}
      >
        <div className="d-flex w-100 justify-content-between">
          <h5 className="mb-1">
            <strong>{this.props.filmName} </strong>
            <br />
            {moment(this.props.sessionDate).format('MMMM Do YYYY, hh:mm:ss a')}
          </h5>
          <small>Hall {this.props.hallName}</small>
        </div>
        <p className="mb-1">
          Cinema: {this.props.cinemaName}, City: {this.props.cinemaCity}
        </p>
      </a>
    );
  }
}

export { Session };
