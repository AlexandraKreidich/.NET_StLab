import fetch from 'isomorphic-fetch';
import {requestSessions, receiveSessions} from './ActionCreators'

export function fetchFilms() {
  const requestOptions = {
    method: 'GET',
    headers: {
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*'
    }
  }
  return function(dispatch) {
    dispatch(requestSessions())
    return fetch('http://localhost:65436/api/sessions', requestOptions)
      .then(function(response) {
      return response.json();
    }).then(function(response) {
      dispatch(receiveSessions(response));
    })
  }
}
