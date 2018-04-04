import React from "react";
import { combineReducers, createStore, applyMiddleware } from "redux";
import { userReducer } from "./user/reducers/User";
import { filmReducer } from "./films/reducers/Film";
import { sessionReducer } from "./sessions/reducers/Session";
import { HallReducer, hallReducer } from "./hall/reducers/Hall";
import { reducer as formReducer } from "redux-form";
import ReduxThunk from "redux-thunk";
import { SearchBarReducer } from "./searchBar/reducers/SearchBar";

import { fetchHallModel } from "./hall/actions/Actions";

const rootReducer = combineReducers({
  user: userReducer,
  film: filmReducer,
  session: sessionReducer,
  form: formReducer,
  searchBar: SearchBarReducer,
  hall: hallReducer
});

const store = createStore(rootReducer, applyMiddleware(ReduxThunk));

store.dispatch(fetchHallModel(1)).then(function() {
  console.log(store.getState());
});

export { store };
