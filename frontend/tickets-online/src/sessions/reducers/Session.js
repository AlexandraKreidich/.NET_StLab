import {requestSessions, receiveSessions} from '../actions/ActionCreators'
import {REQUEST_SESSIONS, RECEIVE_SESSIONS} from '../actions/ActionTypes'

const initialState = {
  sessions: [],
  isSessionsLoading: false
}

const sessionReducer = function(state = initialState, action) {
  switch (action.type) {
    case REQUEST_SESSIONS:
      return Object.assign({}, state, {isFilmsLoading: true});
    case RECEIVE_SESSIONS:
      return Object.assign({}, state, {films: action.response, isFilmsLoading: false});;
  }
  return state;
}

export {
  sessionReducer
}
