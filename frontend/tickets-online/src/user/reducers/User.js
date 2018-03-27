import {
  setUser,
  registerUser,
  failRegistration,
  loginUser,
  failLogin,
  logoutUser
} from '../actions/ActionCreators'

import {
  REGISTER_USER,
  FAIL_REGISTRATION,
  LOGIN_USER,
  FAIL_LOGIN,
  SET_USER,
  LOGOUT_USER
} from '../actions/ActionTypes';

const initialState = {
  isRegistrationInProgress: false,
  isRegistrationFailed: false,
  isLoginInProgress: false,
  isLoginFailed: false,
  userData: {
    id: 0,
    userRole: null,
    email: null,
    firstName: null,
    lastName: null,
    token: null
  }
}

const userReducer = function(state = initialState, action) {
  switch (action.type) {
    case REGISTER_USER:
      return Object.assign({}, state, {isRegistrationInProgress: true});
    case FAIL_REGISTRATION:
      return Object.assign({}, state, {isRegistrationFailed: true});
    case LOGIN_USER:
      return Object.assign({}, state, {isLoginInProgress: true});
    case FAIL_LOGIN:
      return Object.assign({}, state, {isLoginFailed: true});
    case LOGOUT_USER:
      return Object.assign({}, state, {
        isLoginInProgress: false,
        userData: {
          id: 0,
          userRole: null,
          email: null,
          firstName: null,
          lastName: null,
          token: null
        }
      });
    case SET_USER:
      return Object.assign({}, state, {
        isLoginInProgress: state.isLoginFailed,
        userData: {
          ...state.userData,
          id: state.isLoginFailed
            ? 0
            : action.user.id,
          userRole: state.isLoginFailed
            ? null
            : action.user.userRole,
          email: state.isLoginFailed
            ? null
            : action.user.email,
          firstName: state.isLoginFailed
            ? null
            : action.user.firstName,
          lastName: state.isLoginFailed
            ? null
            : action.user.lastName,
          token: state.isLoginFailed
            ? null
            : action.user.token
        }
      });
  }
  return state;
}

export {
  userReducer
}
