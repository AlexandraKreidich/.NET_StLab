import React from 'react';

import '../../bootstrap.css';
import '../../index.css';

class Service extends React.Component {
  render() {
    return (
      <li className="list-group-item d-flex justify-content-between align-items-center">
        {this.props.name}
        <span className="badge badge-primary badge-pill badge-for-service">
          {this.props.amount}
        </span>
      </li>
    );
  }
}

export { Service };
