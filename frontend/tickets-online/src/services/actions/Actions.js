import { requestServicesForSession, receiveServicesForSession } from './ActionCreators';
import { url } from '../../config';

function fetchServicesForSessions(sessionId) {
  const requestOptions = {
    method: 'GET',
    headers: {
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*'
    }
  };
  return function(dispatch) {
    dispatch(requestServicesForSession());

    return fetch(url + 'api/sessions/' + sessionId + '/services', requestOptions)
      .then(function(response) {
        return response.json();
      })
      .then(function(response) {
        dispatch(receiveServicesForSession(response));
      });
  };
}

export { fetchServicesForSessions };
