import React from 'react';
import PropTypes from 'prop-types';
import { Place } from './Place';

import '../../bootstrap.css';
import '../../index.css';

const Row = ({ rowNumber, places, onPlaceClick }) => {
  console.log(places);
  return (
    <div className="row justify-content-md-center">
      {places.map((place, index) => <Place onPlaceClick={onPlaceClick} key={index} {...place} />)}
    </div>
  );
};

export { Row };
