import { url } from '../../config.js';

import {
  setUser,
  registerUser,
  failRegistration,
  loginUser,
  failLogin
} from '../actions/ActionCreators';

function logInUser(email, password) {
  const requestOptions = {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*'
    },
    body: JSON.stringify({ email, password })
  };

  return function(dispatch) {
    dispatch(loginUser());

    return fetch(url + 'api/account/login', requestOptions)
      .then(function(response) {
        if (response.status === 400) {
          return dispatch(failLogin());
        }
        return response.json();
      })
      .then(function(responseJson) {
        if (responseJson && responseJson.token) {
          dispatch(
            setUser({
              id: responseJson.id,
              userRole: responseJson.userRole,
              email: responseJson.email,
              firstName: responseJson.firstName,
              lastName: responseJson.lastName,
              token: responseJson.token
            })
          );
        }
      })
      .catch(function(error) {
        console.log(error);
      });
  };
}

function registerNewUser(email, firstName, lastName, password) {
  const requestOptions = {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*'
    },
    body: JSON.stringify({ email, firstName, lastName, password })
  };

  return function(dispatch) {
    dispatch(registerUser());

    return fetch(url + 'api/account/register', requestOptions)
      .then(function(response) {
        if (response.status === 400) {
          return dispatch(failRegistration());
        }
        return response.json();
      })
      .then(function(responseJson) {
        if (responseJson && responseJson.token) {
          dispatch(logInUser(responseJson.email, password));
        }
      })
      .catch(function(error) {
        console.log(error);
      });
  };
}

export { logInUser, registerNewUser };
