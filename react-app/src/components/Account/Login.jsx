import React from "react";
import '../../styles/account/style.css'
import {NavLink} from "react-router-dom";
import * as actions from "../../actions/account";
import {connect} from "react-redux";

const Login = (props) => {
    return(
        <body>
        <div className="container">
                <h1 className="form__title">Sign In</h1>
                <div className="form__group">
                    <input className="form__input" placeholder=" "/>
                        <label className="form__label">Username</label>
                </div>
                <div className="form__group">
                    <input type="password" className="form__input" placeholder=" "/>
                        <label className="form__label">Password</label>
                </div>
                <div>
                    <input className="form__check" type="checkbox"/>
                        <label className="form__check">Remember me?</label>
                </div>
                <button type="submit" className="form__button">Sign In</button>
            <br></br>
                    <p className="form_registration">Are you already registered?</p>
                    <p className="signup"><NavLink to='/registration'> Sign Up!</NavLink></p>
        </div>
        </body>
    );
}
const mapStateToProps = state => ({
    diaryList: state.account.list
})

const mapActionToProps = {
    fetchAllDiary: actions.Create
}

export default connect(mapStateToProps, mapActionToProps)(Login);