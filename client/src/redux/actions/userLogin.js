export const userLogin = (newUser) => {
    return {
        type: 'USERLOGIN',
        payload: newUser
    };

};