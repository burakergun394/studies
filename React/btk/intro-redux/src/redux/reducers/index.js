import { combineReducers } from "redux";
import counterReducer from "./counterReducers";

const reducers = combineReducers({
  counterReducer, // equals of counterReducer: counterReducer
});

export default reducers;
