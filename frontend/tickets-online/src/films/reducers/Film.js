import {requestFilms, receiveFilms} from '../actions/ActionCreators'
import {REQUEST_FILMS, RECEIVE_FILMS} from '../actions/ActionTypes'

const initialState = {
  films: [],
  isFilmsLoading: false
}

const filmReducer = function(state = initialState, action) {
  switch (action.type) {
    case REQUEST_FILMS:
      return Object.assign({}, state, {isFilmsLoading: true});
    case RECEIVE_FILMS:
      return Object.assign({}, state, {films: action.response, isFilmsLoading: false});;
  }
  return state;
}

export {
  filmReducer
}
