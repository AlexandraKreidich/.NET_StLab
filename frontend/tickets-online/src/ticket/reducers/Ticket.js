import { NEW_TICKET_REQUEST, NEW_TICKET_RESPONSE, USER_TICKETS_REQUEST, USER_TICKETS_RESPONSE } from '../actions/ActionTypes';

const initialState = {
  newTicket: [],
  isBookingTicketInProcess: false
  userTickets: [],
  inUserTicketsLoading: false
};

const ticketsReducer = function(state = initialState, action) {
  switch (action.type) {
    case NEW_TICKET_REQUEST:
      return {
        ...state,
        isBookingTicketInProcess: true
      };
    case NEW_TICKET_RESPONSE:
      return {
        ...state,
        newTicket: action.response,
        isBookingTicketInProcess: false
      };
    case USER_TICKETS_REQUEST:
      return {
        ...state,
        inUserTicketsLoading: true
      }
    case USER_TICKETS_RESPONSE:
      return {
        ..state,
        userTickets: action.response,
        inUserTicketsLoading: false
      }
    default:
      return state;
  }
};

export { ticketsReducer };
