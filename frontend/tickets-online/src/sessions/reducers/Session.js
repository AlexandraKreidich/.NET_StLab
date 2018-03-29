import {requestSessions, receiveSessions} from '../actions/ActionCreators'
import {SESSIONS_REQUEST, SESSIONS_RESPONSE} from '../actions/ActionTypes'

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
  }
  return state;
}

export {
  sessionReducer
}
