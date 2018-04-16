import React from 'react';

import '../../bootstrap.css';
import '../../index.css';

function countPriceForTicket(ticket) {
  let price = ticket.sessionPrice;
  ticket.services.forEach(element => {
    price += element.price * element.amount;
  });
  return price;
}

class TicketInfo extends React.Component {
  render() {
    return (
      <div className="text-center col-md-6">
        <h3> Ticket Info: </h3>
        <p>
          {' '}
          Cinema: {this.props.ticket.cinemaName} Hall: {this.props.ticket.hallName}{' '}
        </p>
        <p> Film: {this.props.ticket.filmName} </p>
        <p>
          {' '}
          Row: {this.props.ticket.rowNumber} Place: {this.props.ticket.placeNumber} Place type:{' '}
          {this.props.ticket.placeType.name}
        </p>
        <p> Price: {countPriceForTicket(this.props.ticket)} </p>

        <div className="d-flex justify-content-center">
          <button type="button" className="btn btn-success ticket-info-btn">
            Pay now
          </button>
          <button type="button" className="btn btn-secondary">
            Pay later
          </button>
        </div>
      </div>
    );
  }
}

export { TicketInfo };
