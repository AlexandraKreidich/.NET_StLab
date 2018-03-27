import React from 'react'
import {combineReducers, createStore, applyMiddleware} from 'redux'
import {userReducer} from './user/reducers/User'
import {filmReducer} from './films/reducers/Film'
import { reducer as formReducer } from 'redux-form'
import ReduxThunk from 'redux-thunk'


const rootReducer = combineReducers({
  user: userReducer,
  film: filmReducer,
  form: formReducer
})

const store = createStore(rootReducer, applyMiddleware(ReduxThunk));

export { store }
