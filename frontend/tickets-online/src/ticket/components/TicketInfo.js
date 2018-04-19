import React from 'react';
import { TicketStatus } from '../../shared/TicketStatus';

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
  constructor(props) {
    super(props);
    this.onPayNowBtnClick = this.onPayNowBtnClick.bind(this);
    this.onCancelBtnClick = this.onCancelBtnClick.bind(this);
  }

  onPayNowBtnClick() {
    this.props.onPayNowBtnClick(this.props.ticket.ticketId);
  }

  onCancelBtnClick() {
    this.props.onCancelBtnClick(this.props.ticket.ticketId);
  }

  render() {
    return (
      <div className="text-center col-md-6">
        <h3> Ticket Info: </h3>
        <p>
          Cinema: {this.props.ticket.cinemaName} Hall: {this.props.ticket.hallName}
        </p>
        <p> Film: {this.props.ticket.filmName} </p>
        <p>
          Row: {this.props.ticket.rowNumber} Place: {this.props.ticket.placeNumber} Place type:
          {this.props.ticket.placeType.name}
        </p>
        <p> Price: {countPriceForTicket(this.props.ticket)} </p>
        <p>
          Status:
          {this.props.ticket.ticketStatus === TicketStatus.InProcess ? 'In process' : 'Paid'}
        </p>
        <div className="d-flex justify-content-center">
          {this.props.ticket.ticketStatus === TicketStatus.InProcess && (
            <button
              onClick={this.onPayNowBtnClick}
              type="button"
              className="btn btn-success ticket-info-btn"
            >
              Pay now
            </button>
          )}
          {this.props.ticket.ticketStatus === TicketStatus.InProcess && (
            <button
              onClick={this.props.onPayLaterBtnClick}
              type="button"
              className="btn btn-secondary ticket-info-btn"
            >
              Pay later
            </button>
          )}
          <button onClick={this.onCancelBtnClick} type="button" className="btn btn-danger">
            Cancel
          </button>
        </div>
      </div>
    );
  }
}

export { TicketInfo };
