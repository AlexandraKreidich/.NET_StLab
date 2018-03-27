import fetch from 'isomorphic-fetch';
import {requestFilms, receiveFilms} from './ActionCreators'

export function fetchFilms() {
  const requestOptions = {
    method: 'GET',
    headers: {
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*'
    }
  }
  return function(dispatch) {
    dispatch(requestFilms())
    return fetch('http://localhost:64793/api/films/now-playing', requestOptions)
      .then(function(response) {
      return response.json();
    }).then(function(response) {
      dispatch(receiveFilms(response));
    })
  }
}
