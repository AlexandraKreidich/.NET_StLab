import {REQUEST_FILMS, RECEIVE_FILMS} from './ActionTypes';

export function requestFilms() {
  return {type: REQUEST_FILMS}
}

export function receiveFilms(response) {
  return {type: RECEIVE_FILMS, response: response}
}
