import React from 'react';
import { Ticket } from './Ticket';

import '../../bootstrap.css';
import '../../index.css';

const TicketsList = ({ tickets }) => {
  return (
    <div className="d-flex justify-content-center">
      {tickets.map((ticket, index) => <Ticket key={index} ticket={ticket} />)}
    </div>
  );
};

export { TicketsList };
