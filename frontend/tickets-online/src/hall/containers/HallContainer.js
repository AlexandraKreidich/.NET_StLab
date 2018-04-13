import React from 'react';
import { withRouter } from 'react-router-dom';
import { connect } from 'react-redux';
import { fetchHallModel } from '../actions/Actions';
import { Hall } from '../components/Hall';
import PlaceInfo from '../components/PlaceInfo';
import { ServicesList } from '../../services/components/servicesList';
import { fetchServicesForSessions } from '../../services/actions/Actions';

function createRows(places, scheme) {
  const rows = scheme.map(elem => {
    let row = {};
    let rowPlaces = [];
    row.rowNumber = elem.rowNumber;

    places.forEach(element => {
      if (element.rowNumber === elem.rowNumber) {
        rowPlaces.push({
          placeId: element.id,
          placeNumber: element.placeNumber,
          rowNumber: element.rowNumber,
          placePrice: element.price,
          placePriceId: element.priceId,
          placeType: element.type.name,
          placeStatus: element.placeStatus
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
    this.onBookBtnClick = this.onBookBtnClick.bind(this);
    this.onServicesClick = this.onServicesClick.bind(this);
    this.state = {
      rows: [],
      isPlaceChoosen: false,
      placeInfo: null,
      services: [],
      servicesResultPrice: 0
    };
  }

  componentDidMount() {
    this.props
      .fetchHallModel(this.props.match.params.hallId, this.props.match.params.sessionId)
      .then(() => {
        this.setState({
          rows: createRows(this.props.hall.hall.placesApi, this.props.hall.hall.hallSchemeApiModels)
        });
      });
    this.props.fetchServicesForSessions(this.props.match.params.sessionId).then(() => {
      this.setState({
        services: this.props.services.services
      });
    });
  }

  onPlaceClick(rowNumber, placeNumber) {
    if (!this.state.isPlaceChoosen) {
      this.setState({
        isPlaceChoosen: true,
        placeInfo: this.state.rows[rowNumber - 1].places[placeNumber - 1]
      });
    } else {
      if (
        this.state.placeInfo.rowNumber === rowNumber &&
        this.state.placeInfo.placeNumber === placeNumber
      ) {
        this.setState({
          isPlaceChoosen: false,
          placeInfo: null
        });
      } else {
        this.setState({
          isPlaceChoosen: true,
          placeInfo: this.state.rows[rowNumber - 1].places[placeNumber - 1]
        });
      }
    }
  }

  onServicesClick(operation, serviceId) {
    let newServices = [];
    let t = this;
    switch (operation) {
      case 'plus':
        newServices = this.state.services.map(function(elem) {
          if (elem.id === serviceId) {
            elem.amount += 1;
            t.setState({
              servicesResultPrice: t.state.servicesResultPrice + elem.price
            });
            return elem;
          }
          return elem;
        });
        break;
      case 'minus':
        newServices = this.state.services.map(function(elem) {
          if (elem.id === serviceId) {
            if (elem.amount >= 1) {
              elem.amount -= 1;
              t.setState({
                servicesResultPrice: t.state.servicesResultPrice - elem.price
              });
            } else {
              elem.amount = 0;
            }
            return elem;
          }
          return elem;
        });
        break;
      default:
        break;
    }
    this.setState({
      services: newServices
    });
  }

  onBookBtnClick() {
    let servicesArr = [];
    this.state.services.forEach(function(elem) {
      if (elem.amount !== 0) {
        servicesArr.push({
          id: elem.id,
          amount: elem.amount
        });
      }
    });
    let newTicket = {
      priceId: this.state.placeInfo.placePrice,
      services: servicesArr.length !== 0 ? servicesArr : null
    };
    console.log(newTicket);
  }

  render() {
    return (
      <div className="text-center hall-container">
        {this.props.hall.hall && (
          <h3 className="hall-model__header">
            <strong> Cinema: </strong> {this.props.hall.hall.cinemaName} <strong> Hall: </strong>{' '}
            {this.props.hall.hall.hallName}
          </h3>
        )}
        {this.props.services.services.length !== 0 && (
          <ServicesList onClick={this.onServicesClick} services={this.state.services} />
        )}
        {this.props.services.services.length !== 0 && (
          <p className="services-price-text">Result price: {this.state.servicesResultPrice}</p>
        )}
        {this.props.hall.hall && <Hall onPlaceClick={this.onPlaceClick} rows={this.state.rows} />}
        {this.state.isPlaceChoosen && (
          <PlaceInfo {...this.state.placeInfo} onBookBtnClick={this.onBookBtnClick} />
        )}
      </div>
    );
  }
}

const mapStateToProps = function(store) {
  return {
    hall: store.hall,
    services: store.service
  };
};

const mapDispatchToProps = dispatch => ({
  fetchHallModel: (hallId, sessionId) => dispatch(fetchHallModel(hallId, sessionId)),
  fetchServicesForSessions: sessionId => dispatch(fetchServicesForSessions(sessionId))
});

const HallContainer = withRouter(connect(mapStateToProps, mapDispatchToProps)(HallModelContainer));

export { HallContainer };
