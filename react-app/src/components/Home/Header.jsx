import React from "react";
import '../../styles/home/style.css';
import {NavLink} from "react-router-dom";

const Header = (props) => {
    return(
        <div className="header">
            <div className="container">
                <div className="nav__menu">
                    <div className="nav__menu__item1">
                        <NavLink to="/">LIFE BALANCE</NavLink>
                    </div>
                    <div className="nav__menu__item2">
                        <NavLink to="api/diary">DIARY</NavLink>
                    </div>
                    <div className="nav__menu__item3">
                        <NavLink to="/profile">PROFILE</NavLink>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default Header;