import React, {useState, useEffect} from 'react';
import { connect } from 'react-redux';
import * as actions from "../actions/diary";

const Diary = (props) => {
    
    useEffect(() => {
        props.fetchAllDiary()
    }, [])
    
    return(
        <div>diary not form</div>
    )
}

const mapStateToProps = state => ({
    diaryList: state.diary.diaryList
})

const mapActionToProps = {
    fetchAllDiary: actions.fetchAll

export default connect(mapStateToProps, mapActionToProps)(Diary);