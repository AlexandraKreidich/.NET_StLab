import React from 'react';
import { TicketInfo } from './TicketInfo';
import { TicketServicesList } from './TicketServicesList';

import '../../bootstrap.css';
import '../../index.css';

class Ticket extends React.Component {
  render() {
    return (
      <div className="alert alert-success ticket-info-alert col-md-8">
        <div className="row">
          <TicketInfo
            onPayLaterBtnClick={this.props.onPayLaterBtnClick}
            onPayNowBtnClick={this.props.onPayNowBtnClick}
            onCancelBtnClick={this.props.onCancelBtnClick}
            ticket={this.props.ticket}
          />
          {this.props.ticket.services.length !== 0 && (
            <TicketServicesList services={this.props.ticket.services} />
          )}
        </div>
      </div>
    );
  }
}

export { Ticket };
