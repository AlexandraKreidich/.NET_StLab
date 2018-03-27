import React from 'react'
import {Field, reduxForm} from 'redux-form'

const LoginFormValidation = values => {

  const errors = {}

  if (!values.password) {
    errors.password = 'Required'
  }

  if (!values.email) {
    errors.email = 'Required'
  }

  if (!/^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$/i.test(values.email)) {
    errors.email = 'Invalid email address'
  }

  return errors
}

export {
  LoginFormValidation
}
