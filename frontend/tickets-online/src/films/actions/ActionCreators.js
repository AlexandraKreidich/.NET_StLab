import {REQUEST_FILMS, RECEIVE_FILMS, SET_VISIBILITY_FILTER} from './ActionTypes';

export function requestFilms() {
  return {type: REQUEST_FILMS}
}

export function receiveFilms(response) {
  return {type: RECEIVE_FILMS, response: response}
}

export function setVisibilityFilter(filters) {
  return {type: SET_VISIBILITY_FILTER, filters: filters}
}
