import React from 'react'
import PropTypes from 'prop-types'
import {Film} from './Film'

import '../../bootstrap.css';
import '../../index.css';

const FilmList = ({films}) => (<ul>
  {films.map((film, index) => (<Film key={index} {...film} /*onClick={() => onFilmClick(index)}*//>))}
</ul>)


FilmList.propTypes = {
  films: PropTypes.arrayOf(
    PropTypes
      .shape({
        id: PropTypes.number.isRequired,
        name: PropTypes.string.isRequired,
        description: PropTypes.string.isRequired
        //startRentDate: PropTypes.string.isRequired,
        //endRentDate: PropTypes.string.isRequired
      })
      .isRequired
    ).isRequired
}

export {
  FilmList
}
