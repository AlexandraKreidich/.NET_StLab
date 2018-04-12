import React from 'react';
import { Place } from './Place';

import '../../bootstrap.css';
import '../../index.css';

const Row = ({ rowNumber, places, onPlaceClick }) => {
  return (
    <div className="row justify-content-md-center">
      {places.map((place, index) => <Place onPlaceClick={onPlaceClick} key={index} {...place} />)}
    </div>
  );
};

export { Row };
