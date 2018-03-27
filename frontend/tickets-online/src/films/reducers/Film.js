import {requestFilms, receiveFilms, setVisibilityFilter} from '../actions/ActionCreators'
import {REQUEST_FILMS, RECEIVE_FILMS, SET_VISIBILITY_FILTER} from '../actions/ActionTypes'

const initialState = {
  films: [],
  isFilmsLoading: false,
  visibilityFilters: {
    filmName: ''
  }
}

const filmReducer = function(state = initialState, action) {
  switch (action.type) {
    case REQUEST_FILMS:
      return Object.assign({}, state, {isFilmsLoading: true});
    case RECEIVE_FILMS:
      return Object.assign({}, state, {
        films: action.response,
        isFilmsLoading: false
      });
    case SET_VISIBILITY_FILTER:
      return Object.assign({}, state, {
        visibilityFilters:{
          ...state.visibilityFilters,
          filmName: action.filters.filmName
        }
      });
  }
  return state;
}

export {
  filmReducer
}
