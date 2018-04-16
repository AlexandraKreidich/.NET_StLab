import {
  NEW_TICKET_REQUEST,
  NEW_TICKET_RESPONSE,
  NEW_TICKET_REQUEST_FAIL,
  USER_TICKETS_REQUEST,
  USER_TICKETS_RESPONSE
} from '../actions/ActionTypes';

const initialState = {
  tickets: null,
  isRequestLoading: false,
  isTicketsLoadingFailed: false,
  isTicketsLoadingSuccess: false,
  isBookingTicketFailed: false,
  isBookingTicketSuccess: false
};

const ticketsReducer = function(state = initialState, action) {
  switch (action.type) {
    case NEW_TICKET_REQUEST:
      return {
        ...state,
        isBookingTicketFailed: false,
        isBookingTicketSuccess: false,
        isRequestLoading: true
      };
    case NEW_TICKET_REQUEST_FAIL:
      return {
        ...state,
        isRequestLoading: false,
        isBookingTicketFailed: true
      };
    case NEW_TICKET_RESPONSE:
      return {
        ...state,
        tickets: new Array(action.response),
        isRequestLoading: false,
        isBookingTicketSuccess: true
      };
    case USER_TICKETS_REQUEST:
      return {
        ...state,
        isRequestLoading: true,
        isTicketsLoadingFailed: false,
        isTicketsLoadingSuccess: false
      };
    case USER_TICKETS_RESPONSE:
      return {
        ...state,
        tickets: action.response,
        isRequestLoading: false,
        isTicketsLoadingSuccess: true
      };
    default:
      return state;
  }
};

export { ticketsReducer };
