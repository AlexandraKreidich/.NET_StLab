import React from 'react';
import PropTypes from 'prop-types';
import moment from 'moment';
import { DATE_FORMAT_FOR_FILM } from '../../shared/DateFormats';

import '../../bootstrap.css';
import '../../index.css';

class Film extends React.Component {
  constructor(props) {
    super(props);
    this.onFilm = this.onFilm.bind(this);
  }

  onFilm(e) {
    e.preventDefault();
    this.props.onFilmClick(this.props.id);
  }

  render() {
    return (
      <div className="card" onClick={this.onFilm}>
        <div className="card-body">
          <h5 className="card-title">
            <strong>{this.props.name}</strong>
          </h5>
          <h6 className="card-subtitle mb-2 text-muted">
            <small>
              Start rent date: {moment(this.props.startRentDate).format(DATE_FORMAT_FOR_FILM)}
            </small>
          </h6>
          <p className="card-text">
            {' '}
            DESCRIPTION: Donec id elit non mi porta gravida at eget metus. Maecenas sed diam eget
            risus varius blandit.
          </p>
          <p className="card-text">
            <small>
              End rent date: {moment(this.props.endRentDate).format(DATE_FORMAT_FOR_FILM)}
            </small>
          </p>
        </div>
      </div>
    );
  }
}

Film.propTypes = {
  onFilmClick: PropTypes.func.isRequired
};

export { Film };
