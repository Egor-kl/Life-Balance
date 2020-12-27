import React from "react";
import '../../styles/home/style.css';

const Footer = (props) => {
    return(
        <div className="footer">
            <div className="footer__row">
                <div className="footer__text">
                    <p>Backend: <a href="https://www.linkedin.com/in/egor-kliutsuk/" target="_blank">Egor Kliutsuk</a>
                    </p>
                    <p>Front-end: <a href="https://github.com/YanSurma" target="_blank">Yan Surma</a></p>
                </div>
            </div>
        </div>
    );
}

export default Footer;