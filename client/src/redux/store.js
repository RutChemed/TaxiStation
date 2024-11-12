import { createStore } from "redux";
import { allReducer } from "./reducers";

const store = createStore(
    allReducer,
);
store.getState();
export default store;