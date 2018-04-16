import {
  NEW_TICKET_REQUEST,
  NEW_TICKET_RESPONSE,
  NEW_TICKET_REQUEST_FAIL,
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
  console.log(response);
  return { type: NEW_TICKET_RESPONSE, response: response };
}

export function requestUserTickets() {
  return { type: USER_TICKETS_REQUEST };
}

export function receiveUserTickets(response) {
  return { type: USER_TICKETS_RESPONSE, response: response };
}
