import React from "react";
import '../../styles/account/style.css'
import {NavLink} from "react-router-dom";

const Registration = (props) => {
    return(
        <div className="container">
                <h1 className="form__title">Sign Up</h1>
                <div className="form__group">
                    <input className="form__input" placeholder=" " />
                        <label className="form__label">Username</label>
                </div>
                <div className="form__group">
                    <input className="form__input" placeholder=" " />
                        <label className="form__label">Email</label>
                </div>
                <div className="form__group">
                    <input type="password" className="form__input" placeholder=" " />
                        <label className="form__label">Password</label>
                </div>
                <div className="form__group">
                    <input className="form__input" placeholder=" " />
                        <label className="form__label">Password confirm</label>
                </div>
                <button type="submit" className="form__button">Sign Up</button>
            <br></br>
                    <p className="form_registration">You have an account?</p>
                    <p className="signup"><NavLink to='/login' > Sign In!</NavLink></p>
        </div>
    );
}

export default Registration;