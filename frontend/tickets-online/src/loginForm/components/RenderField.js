import React from 'react'
import {Field, reduxForm} from 'redux-form'
import {LoginFormValidation} from './LoginFormValidation'
import '../../bootstrap.css';

const RenderField = ({
  input,
  label,
  type,
  meta: {
    touched,
    error
  }
}) => (<div className="form-group">
  <label>{label}</label>
  <div>
    <input {...input} placeholder={label} type={type}/> {touched && error && <span>{error}</span>}
  </div>
</div>);

export {
  RenderField
}
