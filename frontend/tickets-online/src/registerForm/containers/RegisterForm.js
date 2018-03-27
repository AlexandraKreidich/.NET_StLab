import React from 'react'
import {Field, reduxForm} from 'redux-form'
import {RenderField} from '../components/RenderField'
import {registerNewUser} from '../../user/actions/Actions'
import {RegisterFormValidation} from '../components/RegisterFormValidation'
import {connect} from 'react-redux'
import {withRouter} from 'react-router-dom'

class RegisterForm extends React.Component {

  constructor(props) {
    super(props);
  }

  submit = (values) => {
    this.props.registerNewUser(
      values.email,
      values.firstName, 
      values.lastName,
      values.password
    );
  }

  componentWillReceiveProps(newProps) {
    if (newProps.user.token)
      this.props.history.push('/');
  }

  render() {

    const {handleSubmit, error} = this.props;

    return (<div className="top-indent">
      <form onSubmit={handleSubmit(this.submit)}>
        <Field name="email" component={RenderField} label="Email" type="text"/>
        <Field name="firstName" component={RenderField} label="firstName" type="text"/>
        <Field name="lastName" component={RenderField} label="lastName" type="text"/>
        <Field name="password" component={RenderField} label="Password" type="text"/> {error && <strong>{error}</strong>}
        <div>
          <button type="submit" className="btn btn-primary">Register</button>
        </div>
      </form>
    </div>);
  }
}

const mapDispatchToProps = (dispatch) =>({
  registerNewUser: (email, firstName, lastName, password) => dispatch(registerNewUser(email, firstName, lastName, password))
})

const mapStateToProps = (state) =>({
  user: state.user.userData
})

export default withRouter(connect(mapStateToProps, mapDispatchToProps)(reduxForm({form: 'RegisterForm', validate: RegisterFormValidation})(RegisterForm)));
