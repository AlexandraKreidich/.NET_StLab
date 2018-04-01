import React from 'react'
import {combineReducers, createStore, applyMiddleware} from 'redux'
import {userReducer} from './user/reducers/User'
import {filmReducer} from './films/reducers/Film'
import {sessionReducer} from './sessions/reducers/Session'
import { reducer as formReducer } from 'redux-form'
import ReduxThunk from 'redux-thunk'
import {fetchFilms} from './films/actions/Actions'
import {fetchSessions, fetchSessionsForFilm} from './sessions/actions/Actions'
import {BrowserRouter} from 'react-router';

const rootReducer = combineReducers({
  user: userReducer,
  film: filmReducer,
  session: sessionReducer,
  form: formReducer
})

const store = createStore(rootReducer, applyMiddleware(ReduxThunk));

store.dispatch(fetchFilms());
//store.dispatch(push('./'));
// store.dispatch(fetchSessionsForFilm(1)).then(function () {
//   console.log(store.getState());
// });

export { store }
