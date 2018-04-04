import React from 'react';
import { combineReducers, createStore, applyMiddleware } from 'redux';
import { userReducer } from './user/reducers/User';
import { filmReducer } from './films/reducers/Film';
import { sessionReducer } from './sessions/reducers/Session';
import { reducer as formReducer } from 'redux-form';
import ReduxThunk from 'redux-thunk';
import { SearchBarReducer } from './searchBar/reducers/SearchBar';

const rootReducer = combineReducers({
  user: userReducer,
  film: filmReducer,
  session: sessionReducer,
  form: formReducer,
  searchBar: SearchBarReducer
});

const store = createStore(rootReducer, applyMiddleware(ReduxThunk));

export { store };
