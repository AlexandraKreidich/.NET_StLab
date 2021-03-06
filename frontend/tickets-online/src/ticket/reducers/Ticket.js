import {
  NEW_TICKET_REQUEST,
  NEW_TICKET_RESPONSE,
  NEW_TICKET_REQUEST_FAIL,
  TICKET_PAY_REQUEST,
  TICKET_PAY_RESPONSE,
  TICKET_PAY_REQUEST_FAIL,
  TICKET_DELETE_REQUEST,
  TICKET_DELETE_RESPONSE,
  TICKET_DELETE_REQUEST_FAIL,
  USER_TICKETS_REQUEST,
  USER_TICKETS_RESPONSE,
  USER_TICKETS_REQUEST_FAIL
} from '../actions/ActionTypes';

const initialState = {
  tickets: null,
  isRequestLoading: false,
  isTicketsLoadingFailed: false,
  isTicketsLoadingSuccess: false,
  isBookingTicketFailed: false,
  isBookingTicketSuccess: false,
  isDeleteTicketFailed: false,
  isDeleteTicketSuccess: false,
  isPayForTicketFailed: false,
  isPayForTicketSuccess: false
};

const ticketsReducer = function(state = initialState, action) {
  switch (action.type) {
    case USER_TICKETS_REQUEST:
      console.log('userTicketsreq');
      return {
        ...state,
        isRequestLoading: true,
        isTicketsLoadingFailed: false,
        isTicketsLoadingSuccess: false,
        isPayForTicketSuccess: false,
        isDeleteTicketSuccess: false
      };
    case USER_TICKETS_RESPONSE:
      console.log({
        ...state,
        tickets: action.response,
        isRequestLoading: false,
        isTicketsLoadingSuccess: true
      });
      return {
        ...state,
        tickets: action.response,
        isRequestLoading: false,
        isTicketsLoadingSuccess: true
      };
    case USER_TICKETS_REQUEST_FAIL:
      return {
        ...state,
        isRequestLoading: false,
        isTicketsLoadingFailed: true
      };
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
    case TICKET_PAY_REQUEST:
      return {
        ...state,
        isRequestLoading: true,
        isPayForTicketFailed: false,
        isPayForTicketSuccess: false
      };
    case TICKET_PAY_REQUEST_FAIL:
      return {
        ...state,
        isRequestLoading: false,
        isPayForTicketFailed: true
      };
    case TICKET_PAY_RESPONSE:
      return {
        ...state,
        isRequestLoading: false,
        tickets: new Array(action.response),
        isPayForTicketSuccess: true
      };
    case TICKET_DELETE_REQUEST:
      return {
        ...state,
        isRequestLoading: true
      };
    case TICKET_DELETE_REQUEST_FAIL:
      return {
        ...state,
        isRequestLoading: false,
        isDeleteTicketFailed: true
      };
    case TICKET_DELETE_RESPONSE:
      return {
        ...state,
        isRequestLoading: false,
        isDeleteTicketSuccess: true
      };
    default:
      return state;
  }
};

export { ticketsReducer };
