import React from 'react';
import { Ticket } from './Ticket';

import '../../bootstrap.css';
import '../../index.css';

const TicketsListComponent = ({
  tickets,
  onPayLaterBtnClick,
  onPayNowBtnClick,
  onCancelBtnClick
}) => {
  return (
    <div className="d-flex justify-content-center">
      {tickets.map((ticket, index) => (
        <Ticket
          onPayLaterBtnClick={onPayLaterBtnClick}
          onPayNowBtnClick={onPayNowBtnClick}
          onCancelBtnClick={onCancelBtnClick}
          key={index}
          ticket={ticket}
        />
      ))}
    </div>
  );
};

export { TicketsListComponent };
