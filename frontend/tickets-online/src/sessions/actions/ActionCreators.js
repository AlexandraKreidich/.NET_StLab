import {REQUEST_SESSIONS, RECEIVE_SESSIONS} from './ActionTypes'

export function requestSessions() {
  return {type: REQUEST_SESSIONS}
}

export function receiveSessions(response) {
  return {type: RECEIVE_SESSIONS, response: response}
}
