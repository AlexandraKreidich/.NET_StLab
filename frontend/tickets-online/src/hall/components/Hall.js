import React from 'react';
import { Row } from './Row';

import '../../bootstrap.css';
import '../../index.css';

const Hall = ({ rows, onPlaceClick }) => (
  <div className="container col-md-6">
    <div className="alert alert-secondary__hall-scheme  margin-top-indent">
      <p>SCREEN</p>
      <hr />
      {rows.map((row, index) => <Row onPlaceClick={onPlaceClick} key={index} {...row} />)}
    </div>
  </div>
);

export { Hall };
