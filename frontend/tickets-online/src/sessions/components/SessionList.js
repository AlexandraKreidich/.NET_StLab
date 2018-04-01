import React from 'react'
import PropTypes from 'prop-types'
import {Session} from './Session'

import '../../bootstrap.css';
import '../../index.css';

const SessionsList = ({sessions}) => (<ul>
  {sessions.map((session, index) =>
    (<Session key={index} {...session}/>))
  }
</ul>)

export {
  SessionsList
}
