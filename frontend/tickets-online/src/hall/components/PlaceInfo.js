import React from 'react';
import '../../bootstrap.css';
import '../../index.css';

class PlaceInfo extends React.Component {
  constructor(props) {
    super(props);
    this.onClick = this.onClick.bind(this);
  }

  onClick(e) {
    e.preventDefault();
    this.props.onBookBtnClick();
  }

  render() {
    return (
      <div className="row justify-content-md-center place-info">
        <div className="alert alert-light text-center">
          <p className="ticket-info__paragraph">
            {' '}
            {this.props.rowNumber} row, {this.props.placeNumber} place{' '}
          </p>
          <p className="ticket-info__paragraph"> Type: {this.props.placeType} </p>
          <p className="ticket-info__paragraph"> Price: {this.props.placePrice} </p>
          <button type="button" onClick={this.onClick} className="btn btn-primary order-ticket-btn">
            Book it
          </button>
        </div>
      </div>
    );
  }
}

export default PlaceInfo;
