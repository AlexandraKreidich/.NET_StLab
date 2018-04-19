import React from 'react';

import '../../bootstrap.css';
import '../../index.css';
import * as FontAwesome from 'react-icons/lib/fa';

class Service extends React.Component {
  constructor(props) {
    super(props);
    this.onPlusClick = this.onPlusClick.bind(this);
    this.onMinusClick = this.onMinusClick.bind(this);
  }

  onPlusClick(e) {
    this.props.onClick('plus', this.props.id);
  }

  onMinusClick(e) {
    this.props.onClick('minus', this.props.id);
  }

  render() {
    return (
      <li className="list-group-item d-flex justify-content-between align-items-center">
        {this.props.name} (price: {this.props.price})
        <span>
          <span className="badge badge-primary badge-pill badge-for-service">
            {this.props.amount}
          </span>
          <FontAwesome.FaPlus onClick={this.onPlusClick} />
          <FontAwesome.FaMinus onClick={this.onMinusClick} />
        </span>
      </li>
    );
  }
}

export { Service };
