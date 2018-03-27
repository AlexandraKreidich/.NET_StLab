import React from 'react'
import {connect} from 'react-redux'
import {store} from '../../App'
import {FilmList} from '../components/FilmList'
import {fetchFilms} from '../actions/Actions'
import loadImg from '../../load-img.gif'

import '../../bootstrap.css';
import '../../index.css';

class FilmContainer extends React.Component {

  constructor(props){
    super(props);
  }

  componentWillMount(){
    this.props.fetchFilms();
  }

  render() {
    return (<div className="top-indent">
      {this.props.isLoading && <div className="text-center div-load-img"> <img className="img-responsive" width="50px" height="50px" src={loadImg} /></div>}
      {this.props.films && <FilmList films={this.props.films}/>}
    </div>)
  }
};

const mapStateToProps = function(store) {
  return {
    isLoading: store.film.isFilmsLoading,
    films: store.film.films
  }
};

const mapDispatchToProps = (dispatch) =>({
  fetchFilms: () => dispatch(fetchFilms())
});

const FilmListContainer = connect(mapStateToProps, mapDispatchToProps)(FilmContainer);

export {
  FilmListContainer
}
