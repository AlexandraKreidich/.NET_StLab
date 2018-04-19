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
  USER_TICKETS_RESPONSE
} from './ActionTypes';

export function createNewTicket() {
  return { type: NEW_TICKET_REQUEST };
}

export function failCreateNewTicket() {
  return { type: NEW_TICKET_REQUEST_FAIL };
}

export function receiveNewTicket(response) {
  return { type: NEW_TICKET_RESPONSE, response: response };
}

export function payForTicket() {
  return { type: TICKET_PAY_REQUEST };
}

export function failPayForTicket() {
  return { type: TICKET_PAY_REQUEST_FAIL };
}

export function receivePayedTicket(response) {
  return { type: TICKET_PAY_RESPONSE, response: response };
}

export function deleteTicket() {
  return { type: TICKET_DELETE_REQUEST };
}

export function failDeleteTicket() {
  return { type: TICKET_DELETE_REQUEST_FAIL };
}

export function finishDeleteTicket() {
  return { type: TICKET_DELETE_RESPONSE };
}

export function requestUserTickets() {
  return { type: USER_TICKETS_REQUEST };
}

export function receiveUserTickets(response) {
  return { type: USER_TICKETS_RESPONSE, response: response };
}
