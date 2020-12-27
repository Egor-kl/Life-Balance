import React, {useEffect} from "react";
import ProfileItem from "./ProfileItem";
import '../../styles/profile/style.css'
import * as actions from "../../actions/diary";
import {connect} from "react-redux";

const Profile = (props) => {

    useEffect(() => {
        props.fetchAllDiary()
    }, [])

    return(
        <div className="content">
            <div className="background">
                <div className="container">
                    <div className="profile">
                        <div className="profile__about">
                            <div className="profile__about__title">
                                <p>PROFILE</p>
                            </div>
                            <div className="profile__logout">
                                <form method="post" asp-controller="Account" asp-action="Logout">
                                    <input type="submit" asp-controller="Account" asp-action="Logout" value="Logout"/>
                                </form>
                            </div>
                            <div className="profile__menu">
                                <div className="profile__menu__item1">
                                    <a className="menu_item1" href="#">DIARY</a>
                                </div>
                            </div>
                        </div>
                        <div className="profile_entries">
                            <div className="about__entries">
                                <p>ENTRIES</p>
                            </div>
                            <div className="profile__menu__entries">
                                {
                                    props.diaryList.map((diary) => {
                                        return (<ProfileItem id={diary.id} date={diary.date} title = {diary.title} entries ={diary.entries}/>)
                                    })
                                }
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}

const mapStateToProps = state => ({
    diaryList: state.diary.list
})

const mapActionToProps = {
    fetchAllDiary: actions.fetchAll,
    deleteById: actions.Delete,
    updateDiary: actions.Update
}

export default connect(mapStateToProps, mapActionToProps)(Profile);