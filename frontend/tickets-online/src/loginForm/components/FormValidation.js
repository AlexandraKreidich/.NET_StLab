import React from 'react'
import {Field, reduxForm} from 'redux-form'
import { required, email } from 'redux-form-validators'

let validations = {
  email:    [required(), email()],
  password: [required()],
  firstName: [required()],
  lastName: [required()]
}

const validate = (values) => {
  const errors = {}
  for (let field in validations) {
    let value = values[field]
    errors[field] = validations[field]
      .map(validateField => {
        return validateField(value, values)
      })
      .find(x => x)
  }
  return errors
}

export {
  validate
}
