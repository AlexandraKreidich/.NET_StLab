import React from 'react';
import { withRouter } from 'react-router-dom';
import { connect } from 'react-redux';

import '../../bootstrap.css';
import '../../index.css';

class TicketsList extends React.Component {
  constructor(props) {
    super(props);
  }

  componentDidMount() {
    if (
      !this.props.ticket.isBookingTicketSuccess &&
      !this.props.ticket.isBookingTicketInProcess &&
      !this.props.ticket.isBookingTicketFailed
    ) {
      this.props.history.push('/films');
    }
  }

  render() {
    return <TicketsList tickets={this.props.ticket.tickets} />;
  }
}

const mapStateToProps = function(store) {
  return {
    user: store.user,
    ticket: store.ticket
  };
};

const mapDispatchToProps = dispatch => ({});

const TicketsListContainer = withRouter(connect(mapStateToProps, mapDispatchToProps)(TicketsList));

export { TicketsListContainer };
