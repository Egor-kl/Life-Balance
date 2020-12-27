import React from "react";
import '../../styles/home/style.css';
import {NavLink} from "react-router-dom";

const Content = (props) => {
    return(
        <div className="content">
            <div className="background">
                <div className="container">
                    <div className="about__block">
                        <div className="getstart">
                            <div className="button"><NavLink to="api/diary">Get started!</NavLink></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default Content;

