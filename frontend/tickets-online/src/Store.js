import { combineReducers, createStore, applyMiddleware, compose } from 'redux';
import { userReducer } from './user/reducers/User';
import { filmReducer } from './films/reducers/Film';
import { sessionReducer } from './sessions/reducers/Session';
import { hallReducer } from './hall/reducers/Hall';
import { reducer as formReducer } from 'redux-form';
import ReduxThunk from 'redux-thunk';
import { SearchBarReducer } from './searchBar/reducers/SearchBar';
import { serviceReducer } from './services/reducers/Service';
import { ticketsReducer } from './ticket/reducers/Ticket';
import { composeWithDevTools } from 'redux-devtools-extension';

const rootReducer = combineReducers({
  user: userReducer,
  film: filmReducer,
  session: sessionReducer,
  form: formReducer,
  searchBar: SearchBarReducer,
  hall: hallReducer,
  service: serviceReducer,
  ticket: ticketsReducer
});

const composeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;

const enhancer = composeEnhancers(applyMiddleware(ReduxThunk));

const store = createStore(rootReducer, enhancer);

export { store };
