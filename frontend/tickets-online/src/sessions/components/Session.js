import React from 'react';
import moment from 'moment';
import { DATE_FORMAT_FOR_SESSION } from '../../shared/DateFormats';

import '../../bootstrap.css';
import '../../index.css';

class Session extends React.Component {
  constructor(props) {
    super(props);
  }

  onClick = e => {
    e.preventDefault();
    this.props.onSessionClick(this.props.hallId, this.props.id);
  };

  render() {
    return (
      <div className="card" onClick={this.onClick}>
        <div className="card-body">
          <h5 className="card-title">
            <strong>{this.props.filmName} </strong>
          </h5>
          <h6 className="card-subtitle mb-2 text-muted">
            {moment(this.props.sessionDate).format(DATE_FORMAT_FOR_SESSION)}
          </h6>
          <p className="card-text">
            <small>Hall {this.props.hallName}</small>
          </p>
          <p className="card-text">
            <small>
              Cinema: {this.props.cinemaName}, City: {this.props.cinemaCity}
            </small>
          </p>
        </div>
      </div>
    );
  }
}

export { Session };
