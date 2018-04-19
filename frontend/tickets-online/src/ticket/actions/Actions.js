import {
  createNewTicket,
  failCreateNewTicket,
  receiveNewTicket,
  payForTicket,
  failPayForTicket,
  receivePayedTicket,
  deleteTicket,
  failDeleteTicket,
  finishDeleteTicket
} from './ActionCreators';
import { url } from '../../config';
import { store } from '../../Store';
import HttpStatus from 'http-status-codes';

function fetchCreateNewTicket(newTicket, token) {
  let authHeader = 'Bearer ' + token;
  const requestOptions = {
    method: 'PUT',
    headers: {
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*',
      Authorization: authHeader
    },
    body: JSON.stringify(newTicket)
  };
  return function(dispatch) {
    dispatch(createNewTicket());

    return fetch(url + 'api/tickets', requestOptions)
      .then(function(response) {
        if (response.status !== HttpStatus.OK) {
          dispatch(failCreateNewTicket());
        } else {
          return response.json();
        }
      })
      .then(function(response) {
        dispatch(receiveNewTicket(response));
      });
  };
}

function runPayForTicket(ticketId, token) {
  let authHeader = 'Bearer ' + token;
  const requestOptions = {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*',
      Authorization: authHeader
    }
  };
  return function(dispatch) {
    dispatch(payForTicket());

    return fetch(url + 'api/tickets/' + ticketId + '/pay', requestOptions)
      .then(function(response) {
        if (response.status !== HttpStatus.OK) {
          dispatch(failPayForTicket());
        } else {
          return response.json();
        }
      })
      .then(function(response) {
        dispatch(receivePayedTicket(response));
      });
  };
}

function runDeleteTicket(ticketId, token) {
  let authHeader = 'Bearer ' + token;
  const requestOptions = {
    method: 'DELETE',
    headers: {
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*',
      Authorization: authHeader
    }
  };
  return function(dispatch) {
    dispatch(deleteTicket());

    return fetch(url + 'api/tickets/' + ticketId, requestOptions)
      .then(function(response) {
        if (response.status !== HttpStatus.OK) {
          dispatch(failDeleteTicket());
        }
      })
      .then(() => {
        dispatch(finishDeleteTicket());
      });
  };
}

export { fetchCreateNewTicket, runPayForTicket, runDeleteTicket };
