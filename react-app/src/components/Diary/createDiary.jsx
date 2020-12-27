import React, {useState, useEffect} from 'react';
import { connect } from 'react-redux';
import * as actions from "../../actions/diary";
import '../../styles/diary/style.css';

const CreateDiary = (props) => {

    useEffect(() => {
        props.fetchAllDiary()
    }, [])

    return(
        <div className="content">
            <div className="background">
                <div className="container">
                    <div className="diary__block">
                        <div className="diary__field1">
                            <div className="title1">
                                <p>TITLE</p>
                            </div>
                            <div className="textarea1">
                                <textarea className="title" value={props.data.title}></textarea>
                            </div>
                        </div>
                        <div className="diary__field2">
                            <div className="title2">
                                <p>ENTRIES</p>
                            </div>
                            <div className="textarea2">
                                <textarea className="notes" value={props.data.entries}></textarea>
                            </div>
                        </div>
                        <div className="button">
                            <button type="submit" className="button__button">
                                SEND
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}

const mapStateToProps = state => ({
    diaryList: state.diary.diaryList
})

const mapActionToProps = {
    fetchAllDiary: actions.fetchAll,
    deleteById: actions.Delete
}

export default connect(mapStateToProps, mapActionToProps)(CreateDiary);