import {
  requestFilms,
  receiveFilms,
  setVisibilityFilter,
  requestSessionsForFilm,
  receiveSessionsForFilm
} from '../actions/ActionCreators';

import {
  FILMS_REQUEST,
  FILMS_RESPONSE,
  VISIBILITY_FILTER_SET,
  SESSIONS_FOR_FILM_REQUEST,
  SESSIONS_FOR_FILM_RESPONSE
} from '../actions/ActionTypes';

const initialState = {
  films: [],
  isFilmsLoading: false,
  visibilityFilters: {
    filmName: ''
  }
};

const filmReducer = function(state = initialState, action) {
  switch (action.type) {
    case FILMS_REQUEST:
      return {
        ...state,
        isFilmsLoading: true
      };
    case FILMS_RESPONSE:
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
      };
  }
  return state;
};

export {
  filmReducer
}
