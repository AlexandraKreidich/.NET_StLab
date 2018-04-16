import React from 'react';
import { Service } from './service';

import '../../bootstrap.css';
import '../../index.css';

const ServicesList = ({ services }) => {
  return (
    <div className="text-center col-md-6">
      <ul className="list-group">
        {services.map((service, index) => <Service key={index} {...service} />)}
      </ul>
    </div>
  );
};

export { ServicesList };
