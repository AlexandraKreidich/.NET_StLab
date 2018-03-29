import {SESSIONS_REQUEST, SESSIONS_RESPONSE} from './ActionTypes'

export function requestSessions() {
  return {type: SESSIONS_REQUEST}
}

export function receiveSessions(response) {
  return {type: SESSIONS_RESPONSE, response: response}
}
