import {FILMS_REQUEST, FILMS_RESPONSE, VISIBILITY_FILTER_SET} from './ActionTypes';

export function requestFilms() {
  return {type: FILMS_REQUEST}
}

export function receiveFilms(response) {
  return {type: FILMS_RESPONSE, response: response}
}

export function setVisibilityFilter(filters) {
  return {type: VISIBILITY_FILTER_SET, filters: filters}
}
