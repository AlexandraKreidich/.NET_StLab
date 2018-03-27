import React from 'react'
import PropTypes from 'prop-types'

import '../../bootstrap.css';
import '../../index.css';

const Film = ({name, description, startRentDate, endRentDate}) => (
  <a href="#" className="film-item list-group-item list-group-item-action flex-column align-items-start">
  <div className="d-flex w-100 justify-content-between">
    <h5 className="mb-1"><strong>{name}</strong></h5>
  <small>Start rent date: {new Date(startRentDate).toDateString()}</small>
  </div>
  <p className="mb-1">DESCRIPTION: Donec id elit non mi porta gravida at eget metus. Maecenas sed diam eget risus varius blandit.</p>
<small>End rent date: {new Date(endRentDate).toDateString()}</small>
</a>)

/*Film.propTypes = {
  onClick: PropTypes.func.isRequired,
  text: PropTypes.string.isRequired
}*/

export {
  Film
}
