import React from 'react';
import PropTypes from 'prop-types';

import '../../bootstrap.css';
import '../../index.css';

class Place extends React.Component {
  constructor(props) {
    super(props);
    this.onClick = this.onClick.bind(this);
  }

  onClick(e) {
    e.preventDefault();
    this.props.onPlaceClick(this.props.placeId, this.props.placePrice);
  }

  render() {
    return (
      <button onClick={this.onClick} type="button" className="btn btn-outline-primary">
        {this.props.placeNumber}
      </button>
    );
  }
}

export { Place };
