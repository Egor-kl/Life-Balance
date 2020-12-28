import React from "react";
import {Link, NavLink} from "react-router-dom";
import {useToasts} from "react-toast-notifications";
import * as actions from "../../actions/diary";
import {connect} from "react-redux";
import mapStateToProps from "react-redux/lib/connect/mapStateToProps";

const ProfileItem = (props) => {

    const { addToast } = useToasts()

    const onDelete = id => {
        if (window.confirm('Are you sure to delete this record?'))
            props.deleteById(id, ()=>addToast("Deleted successfully", { appearance: 'info' }))
    }


    return(
        <div className="profile__menu__entries__item1">
            <div className="pr__title">
                <p>{props.title}</p>
            </div>
            <div className="pr__block">
                <div className="pr__input">
                    <textarea disabled >{props.entries}</textarea>
                </div>
                <div className="pr__buttons">
                    <div className="pr__button1">
                        <Link to={{
                            pathname: 'diary/info/'+props.id,
                            state: { id: props.id, date: props.date, title: props.title, entries : props.entries }
                        }}>Info</Link>
                    </div>
                    <div className="pr__button1">
                        <Link to={{
                            pathname: 'diary/edit/'+props.id,
                            state: { id: props.id, date: props.date, title: props.title, entries : props.entries }
                        }}>Edit</Link>
                    </div>
                    <div className="pr__button1">
                        <button onClick={() => onDelete(props.id)}>Delete</button>
                    </div>
                </div>
            </div>
        </div>
    );
}

const mapStateToProp = state => ({
    diaryList: state.diary.list
})

const mapActionToProps = {
    deleteById: actions.Delete
}

export default connect(mapStateToProp, mapActionToProps)(ProfileItem);