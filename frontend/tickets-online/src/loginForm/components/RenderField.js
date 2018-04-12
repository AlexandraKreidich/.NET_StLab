import React from 'react';

import '../../bootstrap.css';
import '../../index.css';

const RenderField = ({ input, label, type, meta: { touched, error } }) => (
  <div className="form-group">
    <label>{label}</label>
    <div>
      <input {...input} placeholder={label} type={type} /> <br />{' '}
      {touched && error && <span className="validation-error-text">{error}</span>}
    </div>
  </div>
);

export { RenderField };
