import React from 'react';
import { TicketInfo } from './TicketInfo';

import '../../bootstrap.css';
import '../../index.css';
import { ServicesList } from '../../services/components/servicesList';

class Ticket extends React.Component {
  render() {
    return (
      <div className="row">
        <TicketInfo ticket={this.props.ticket} />
        <ServicesList services={this.props.ticket.services} />
      </div>
    );
  }
}

export { TicketInfoComponent };
