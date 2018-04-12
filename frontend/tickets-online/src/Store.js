import { combineReducers, createStore, applyMiddleware } from 'redux';
import { userReducer } from './user/reducers/User';
import { filmReducer } from './films/reducers/Film';
import { sessionReducer } from './sessions/reducers/Session';
import { hallReducer } from './hall/reducers/Hall';
import { reducer as formReducer } from 'redux-form';
import ReduxThunk from 'redux-thunk';
import { SearchBarReducer } from './searchBar/reducers/SearchBar';
import { serviceReducer } from './services/reducers/Service';
import { fetchServicesForSessions } from './services/actions/Actions';

const rootReducer = combineReducers({
  user: userReducer,
  film: filmReducer,
  session: sessionReducer,
  form: formReducer,
  searchBar: SearchBarReducer,
  hall: hallReducer,
  service: serviceReducer
});

const store = createStore(rootReducer, applyMiddleware(ReduxThunk));

// store.dispatch(fetchServicesForSessions(1)).then(function() {
//   console.log(store.getState());
// });

export { store };
