import {
  requestSessions,
  receiveSessions,
  requestSessionsForFilm,
  receiveSessionsForFilm,
  requestServicesForSession,
  receiveServicesForSession
} from '../actions/ActionCreators';

import {
  SESSIONS_REQUEST,
  SESSIONS_RESPONSE,
  SESSIONS_FOR_FILM_REQUEST,
  SESSIONS_FOR_FILM_RESPONSE,
  SERVICES_FOR_SESSION_REQUEST,
  SERVICES_FOR_SESSION_RESPONSE
} from '../actions/ActionTypes';

const initialState = {
  sessions: [],
  isSessionsLoading: false
}

const sessionReducer = function(state = initialState, action) {
  switch (action.type) {
    case SESSIONS_REQUEST:
      return {
        ...state,
        isSessionsLoading: true
      };
    case SESSIONS_RESPONSE:
      return {
        ...state,
        sessions: action.response,
        isSessionsLoading: false
      }
    case SESSIONS_FOR_FILM_REQUEST:
      return {
        ...state,
        isSessionsLoading: true
      };
    case SESSIONS_FOR_FILM_RESPONSE:
      return {
        ...state,
        sessions: action.response,
        isSessionsLoading: false
      }
    case SERVICES_FOR_SESSION_REQUEST:

  }
  return state;
}

export {
  sessionReducer
}
