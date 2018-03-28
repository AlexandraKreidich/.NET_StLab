import fetch from 'isomorphic-fetch';
import {requestSessions, receiveSessions} from './ActionCreators';
import {url} from '../../config.js';

export function fetchSessions() {
  const requestOptions = {
    method: 'GET',
    headers: {
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*'
    }
  }
  return function(dispatch) {
    dispatch(requestSessions())
    return fetch(url + 'api/sessions', requestOptions)
      .then(function(response) {
        return response.json();
      })
      .then(function(response) {
        dispatch(receiveSessions(response));
      })
  }
}
