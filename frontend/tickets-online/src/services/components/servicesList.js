import React from 'react';
import { Service } from './service';

import '../../bootstrap.css';
import '../../index.css';

const ServicesList = ({ services, onClick }) => {
  return (
    <div className="container col-md-6">
      <ul className="list-group">
        {services.map((service, index) => <Service key={index} {...service} onClick={onClick} />)}
      </ul>
    </div>
  );
};

export { ServicesList };
