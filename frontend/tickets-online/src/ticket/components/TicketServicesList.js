import React from 'react';
import { TicketService } from './TicketService';

import '../../bootstrap.css';
import '../../index.css';

const TicketServicesList = ({ services }) => {
  return (
    <div className="text-center col-md-6">
      <h3>Services: </h3>
      <ul className="list-group">
        {services.map((service, index) => <TicketService key={index} {...service} />)}
      </ul>
    </div>
  );
};

export { TicketServicesList };
