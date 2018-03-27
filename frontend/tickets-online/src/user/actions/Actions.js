import fetch from 'isomorphic-fetch';

import {
  setUser,
  registerUser,
  failRegistration,
  loginUser,
  failLogin
} from '../actions/ActionCreators'

function logInUser(email, password) {
  console.log(email, password);
  const requestOptions = {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*'
    },
    body: JSON.stringify({email, password})
  }

  return function(dispatch) {
    dispatch(loginUser())
    return fetch('http://localhost:65436/api/account/login', requestOptions).then(function(response) {
      if (!response.ok) {
        return Promise.reject(response.statusText);
      }
      return response.json();
    }).then(function(user) {
      console.log(user);
      if (user && user.token) {
        dispatch(setUser({
          id: user.id,
          userRole: user.userRole,
          email: user.email,
          firstName: user.firstName,
          lastName: user.lastName,
          token: user.token
        }));
      } else {
        dispatch(failLogin());
      }
    });
  }
}

function registerNewUser(email, firstName, lastName, password) {
  const requestOptions = {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*'
    },
    body: JSON.stringify({email, firstName, lastName, password})
  }

  return function(dispatch) {
    dispatch(registerUser())
    return fetch('http://localhost:65436/api/account/register', requestOptions).then(function(response) {
      if (!response.ok) {
        return Promise.reject(response.statusText);
      }
      return response.json();
    }).then(function(user) {
      if (user && user.token) {
        console.log(user);
        dispatch(logInUser(user.email, password));
      } else {
        dispatch(failRegistration());
      }
    });
  }
}

export {logInUser, registerNewUser}
