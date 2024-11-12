const initialState = JSON.parse(localStorage.getItem("user"));
export const userReducer = (state = initialState ,action)=>{
    switch (action.type) {
        case "USERLOGIN":
            state = action.payload;
            console.log(state);
            localStorage.setItem('user',JSON.stringify(state));
            return state;
    }
    return state;
}