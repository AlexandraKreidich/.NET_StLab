import { createNewTicket, receiveNewTicket } from './ActionCreators';
import { url } from '../../config';

function fetchCreateNewTicket(newTicket) {
  const requestOptions = {
    method: 'PUT',
    headers: {
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*'
    },
    body: JSON.stringify(newTicket)
  };
  return function(dispatch) {
    dispatch(requestServicesForSession());

    return fetch(url + 'api/tickets', requestOptions)
      .then(function(response) {
        return response.json();
      })
      .then(function(response) {
        dispatch(receiveNewTicket(response));
      });
  };
}

export { fetchCreateNewTicket };
