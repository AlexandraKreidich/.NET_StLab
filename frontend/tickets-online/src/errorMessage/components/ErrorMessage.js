import React from 'react';

class ErrorMessage extends React.Component {
  render() {
    return (
      <div>
        <div className="d-flex justify-content-center">
          <div className="alert alert alert-danger ticket-info-alert col-md-8">
            <h4>{this.props.errorMessage}</h4>
          </div>
        </div>
      </div>
    );
  }
}

export { ErrorMessage };
