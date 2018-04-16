import { createNewTicket, receiveNewTicket, failCreateNewTicket } from './ActionCreators';
import { url } from '../../config';
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

export { fetchCreateNewTicket };
