import React from 'react';
import { withRouter } from 'react-router-dom';
import { connect } from 'react-redux';
import { fetchHallModel } from '../actions/Actions';
import { Hall } from '../components/Hall';

function createRows(places, scheme) {
  const rows = scheme.map(elem => {
    let row = new Object();
    let rowPlaces = new Array();
    row.rowNumber = elem.rowNumber;

    places.forEach(element => {
      if (element.rowNumber === elem.rowNumber) {
        rowPlaces.push({
          placeId: element.id,
          placeNumber: element.placeNumber
        });
      }
    });

    row.places = rowPlaces;
    return row;
  });
  return rows;
}

class HallModelContainer extends React.Component {
  constructor(props) {
    super(props);
    this.onPlaceClick = this.onPlaceClick.bind(this);
  }

  componentDidMount() {
    this.props.fetchHallModel(this.props.match.params.hallId);
  }

  onPlaceClick(placeId) {
    console.log(placeId);
  }

  render() {
    console.log(this.props.hall.hall);
    return (
      <div>
        {this.props.hall.hall && (
          <Hall
            onPlaceClick={this.onPlaceClick}
            rows={createRows(
              this.props.hall.hall.placesApi,
              this.props.hall.hall.hallSchemeApiModels
            )}
          />
        )}
      </div>
    );
  }
}

const mapStateToProps = function(store) {
  return {
    hall: store.hall
  };
};

const mapDispatchToProps = dispatch => ({
  fetchHallModel: hallId => dispatch(fetchHallModel(hallId))
});

const HallContainer = withRouter(connect(mapStateToProps, mapDispatchToProps)(HallModelContainer));

export { HallContainer };
