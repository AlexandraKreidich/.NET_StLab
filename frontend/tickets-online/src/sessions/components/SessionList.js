import React from 'react';
import { Session } from './Session';

import '../../bootstrap.css';
import '../../index.css';

const SessionsList = ({ sessions, onSessionClick }) => (
  <div className="top-indent row justify-content-center">
    {sessions.map((session, index) => (
      <Session onSessionClick={onSessionClick} key={index} {...session} />
    ))}
  </div>
);

export { SessionsList };
