import {requestFilms, receiveFilms, setVisibilityFilter} from '../actions/ActionCreators'
import {FILMS_REQUEST, FILMS_RECEIVE, VISIBILITY_FILTER_SET} from '../actions/ActionTypes'

const initialState = {
  films: [],
  isFilmsLoading: false,
  visibilityFilters: {
    filmName: ''
  }
}

const filmReducer = function(state = initialState, action) {
  switch (action.type) {
    case FILMS_REQUEST:
      return {
        ...state,
        isFilmsLoading: true
      };
    case FILMS_RECEIVE:
      return {
        ...state,
        films: action.response,
        isFilmsLoading: false
      };
    case VISIBILITY_FILTER_SET:
      return {
        ...state,
        visibilityFilters: {
          ...state.visibilityFilters,
          filmName: action.filters.filmName
        }
      }
  }
  return state;
}

export {
  filmReducer
}
