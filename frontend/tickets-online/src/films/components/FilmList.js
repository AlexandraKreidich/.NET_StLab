import React from 'react';
import PropTypes from 'prop-types';
import { Film } from './Film';

import '../../bootstrap.css';
import '../../index.css';

const FilmList = ({ films, onFilmClick }) => (
  <React.Fragment>
    {films.map((film, index) => <Film key={index} {...film} onFilmClick={onFilmClick} />)}
  </React.Fragment>
);

const propsForFilmsArray = {
  id: PropTypes.number.isRequired,
  name: PropTypes.string.isRequired,
  description: PropTypes.string.isRequired
  //startRentDate: PropTypes.string.isRequired,
  //endRentDate: PropTypes.string.isRequired
};

FilmList.propTypes = {
  films: PropTypes.arrayOf(PropTypes.shape(propsForFilmsArray).isRequired).isRequired
};

export { FilmList };
