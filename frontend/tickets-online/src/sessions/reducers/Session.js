import {requestSessions, receiveSessions} from '../actions/ActionCreators'
import {REQUEST_SESSIONS, RECEIVE_SESSIONS} from '../actions/ActionTypes'

const initialState = {
  sessions: [],
  isSessionsLoading: false
}

const sessionReducer = function(state = initialState, action) {
  switch (action.type) {
    case REQUEST_SESSIONS:
      return {
        ...state,
        isSessionsLoading: true
      };
    case RECEIVE_SESSIONS:
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
