import { combineReducers } from "redux";
import { userReducer } from './userReducer';

export const allReducer = combineReducers({
    usersReducer: userReducer,
});