import React from 'react';
import { withRouter } from 'react-router-dom';
import { connect } from 'react-redux';
import { TicketsListComponent } from '../components/TicketsListComponent';
import { runPayForTicket, runDeleteTicket } from '../actions/Actions';

import '../../bootstrap.css';
import '../../index.css';

class TicketsList extends React.Component {
  constructor(props) {
    super(props);
    this.onPayLaterBtnClick = this.onPayLaterBtnClick.bind(this);
    this.onPayNowBtnClick = this.onPayNowBtnClick.bind(this);
    this.onCancelBtnClick = this.onCancelBtnClick.bind(this);
  }

  componentDidMount() {
    if (
      !this.props.ticket.isBookingTicketSuccess &&
      !this.props.ticket.isRequestLoading &&
      !this.props.ticket.isBookingTicketFailed
    ) {
      this.props.history.push('/films');
    }
  }

  onPayLaterBtnClick() {
    this.props.history.push('/films');
  }

  onPayNowBtnClick(ticketId) {
    this.props.runPayForTicket(ticketId, this.props.user.userData.token);
  }

  onCancelBtnClick(ticketId) {
    this.props.runDeleteTicket(ticketId, this.props.user.userData.token);
  }

  render() {
    if (this.props.ticket.isPayForTicketFailed) {
      return <div>Paying failed!</div>;
    } else if (this.props.ticket.isDeleteTicketFailed) {
      return <div>Deleting failed!</div>;
    } else if (this.props.ticket.isDeleteTicketSuccess) {
      return <div>Deleted!</div>;
    } else {
      return (
        <div>
          {this.props.ticket.isRequestLoading && <p> Loading... </p>}
          {this.props.ticket.tickets && (
            <TicketsListComponent
              onPayLaterBtnClick={this.onPayLaterBtnClick}
              onPayNowBtnClick={this.onPayNowBtnClick}
              onCancelBtnClick={this.onCancelBtnClick}
              tickets={this.props.ticket.tickets}
            />
          )}
        </div>
      );
    }
  }
}

const mapStateToProps = function(store) {
  return {
    user: store.user,
    ticket: store.ticket
  };
};

const mapDispatchToProps = dispatch => ({
  runPayForTicket: (ticketId, token) => dispatch(runPayForTicket(ticketId, token)),
  runDeleteTicket: (ticketId, token) => dispatch(runDeleteTicket(ticketId, token))
});

const TicketsListContainer = withRouter(connect(mapStateToProps, mapDispatchToProps)(TicketsList));

export { TicketsListContainer };
