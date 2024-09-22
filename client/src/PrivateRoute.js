import React from 'react';
import { Redirect, Route } from 'react-router-dom';
import jwt_decode from 'jwt-decode';

const PrivateRoute = ({ component: Component, ...rest }) => {
    const token = localStorage.getItem('token');
    let isAuthenticated = false;

    if (token) {
        const decodedToken = jwt_decode(token);
        const currentTime = Date.now() / 1000;
        if (decodedToken.exp > currentTime) {
            isAuthenticated = true;
        }
    }

    return (
        <Route
            {...rest}
            render={(props) =>
                isAuthenticated ? (
                    <Component {...props} />
                ) : (
                    <Redirect to="/login" />
                )
            }
        />
    );
};

export default PrivateRoute;
@NgModule({
declarations: [SampleComponent]
providers: [ServiceY]
})
class SampleModule {

}


