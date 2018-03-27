import {
  REGISTER_USER,
  FAIL_REGISTRATION,
  LOGIN_USER,
  FAIL_LOGIN,
  SET_USER,
  LOGOUT_USER
} from './ActionTypes';

export function setUser(user) {
  return {type: SET_USER, user: user}
}

export function registerUser(user) {
  return {type: REGISTER_USER}
}

export function failRegistration(){
  return {type: FAIL_REGISTRATION}
}

export function loginUser() {
  return {type: LOGIN_USER}
}

export function failLogin(){
  return {type: FAIL_LOGIN}
}

export function logoutUser() {
  return {type: LOGOUT_USER}
}
